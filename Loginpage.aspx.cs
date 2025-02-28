using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
public partial class Loginpage : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IOLConnectionString"].ToString());
    SoftLensDataContext db = new SoftLensDataContext();
    private const int MaxFailedAttempts = 3;
    private const int LockoutDuration = 10;
    protected void Page_Load(object sender, EventArgs e)
    {
        username.Focus();
    }

    private void Messagebox(string msg)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Windows", "alert('" + msg + "')", true);
    }
    
    private bool Valid()
  {
      
        //AuthenticateUser(username.Value, password.Value);

        // if (!AuthenticateUser(username.Value, password.Value))
        //{
        //    Messagebox(string.Format("Invalid UserName or Pasword"));
        //    return false;

        //}

        //LoginUser(username.Value, password.Value);

        bool _isvalid = true;
        if (username.Value.Trim() != "" && password.Value.Trim() != "")
         {

            var logininfo = from a in db.Logins where a.LoginName == username.Value.Trim() && a.Password == password.Value.Trim()  select new { a.LoginName, a.Password };
            if (logininfo.Count() > 0)
            {
                var user = logininfo.FirstOrDefault(); 
                if (user != null)
                {
                    string expectedPassword = user.Password;
                    string inputPassword = password.Value;

                    // Validate the password and employee code
                    if (IsValidPassword(inputPassword, expectedPassword, username.Value))
                    {
                        var userLogin = db.Logins
                        .FirstOrDefault(x => x.LoginName == username.Value.Trim() && x.Password == password.Value.Trim());

                       

                        if (userLogin != null)
                        {
                           // userLogin.Login_Status = 1;

                        //    db.SubmitChanges();
                        }
                        Session["UserName"] = username;

                    }
                    else
                    {
                        Messagebox("Username/Password Is Incorrect");
                        username.Value = "";
                        password.Value = "";
                        username.Focus();
                        _isvalid = false;
                    }
                }
              }
            else
            {
                Messagebox("User Already Logined or Username/Password Is Incorrect");
                username.Value = "";
                password.Value = "";
                username.Focus();
                _isvalid = false;
            }

     }

        return _isvalid;

    }

  
   

    public bool AuthenticateUser(string username, string password)
    {
        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }

        try
        {
            con.Open();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }

        try
        {

            const int MaxFailedAttempts = 3;
            // Check for lockout status
            SqlCommand cmdCheckLockout = new SqlCommand("SELECT FailedAttempts, LockoutTime FROM UserLoginAttempts WHERE Username = @Username", con);
            cmdCheckLockout.Parameters.AddWithValue("@Username", username);

            SqlDataReader reader = cmdCheckLockout.ExecuteReader();
            int failedAttempts = 0;
            DateTime lockoutTime = DateTime.MinValue;

            if (reader.Read())
            {
                failedAttempts = reader["FailedAttempts"] != DBNull.Value ? Convert.ToInt32(reader["FailedAttempts"]) : 0;
                lockoutTime = reader["LockoutTime"] != DBNull.Value ? Convert.ToDateTime(reader["LockoutTime"]) : DateTime.MinValue;
            }
            reader.Close();

            DateTime lockoutEndTime = lockoutTime.AddMinutes(LockoutDuration);

            if (failedAttempts >= MaxFailedAttempts && lockoutEndTime > DateTime.Now)
            {
                Messagebox(string.Format("Account is locked. Try again after {0}.", lockoutEndTime));
                return false;
            }

            // Authenticate user
            SqlCommand cmdAuth = new SqlCommand(
                "SELECT COUNT(*) FROM Login WHERE LoginName = @LoginName AND Password = @Password ", con);
            cmdAuth.Parameters.AddWithValue("@LoginName", username);
             cmdAuth.Parameters.AddWithValue("@Password", password);

            int userExists = Convert.ToInt32(cmdAuth.ExecuteScalar());

            if (userExists > 0)
            {
                // Reset failed attempts on successful login
                SqlCommand cmdResetAttempts = new SqlCommand(
                    "UPDATE UserLoginAttempts SET FailedAttempts = 0, LockoutTime = NULL WHERE Username = @Username", con);
                cmdResetAttempts.Parameters.AddWithValue("@Username", username);
                cmdResetAttempts.ExecuteNonQuery();

                Console.WriteLine("Login successful!");
                return true;
            }
            else
            {
                // Update failed attempts or insert new record if necessary
                SqlCommand cmdUpdateAttempts = new SqlCommand(@"
                    IF EXISTS (SELECT * FROM UserLoginAttempts WHERE Username = @Username)
                    BEGIN
                        UPDATE UserLoginAttempts
                        SET FailedAttempts = FailedAttempts + 1,
                            LockoutTime = CASE WHEN FailedAttempts + 1 >= @MaxFailedAttempts THEN GETDATE() ELSE LockoutTime END
                        WHERE Username = @Username
                    END
                    ELSE
                    BEGIN
                        INSERT INTO UserLoginAttempts (Username, FailedAttempts, LockoutTime)
                        VALUES (@Username, 1, NULL)
                    END", con);

                cmdUpdateAttempts.Parameters.AddWithValue("@Username", username);
                cmdUpdateAttempts.Parameters.AddWithValue("@MaxFailedAttempts", MaxFailedAttempts);
                cmdUpdateAttempts.ExecuteNonQuery();

                Console.WriteLine("Invalid username or password.");
                return false;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
        finally
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
    }

    static bool IsValidPassword(string inputPassword, string expectedPassword, string username)
    {
        SoftLensDataContext db = new SoftLensDataContext();
         // Check if the input password matches the expected password exactly (case-sensitive)
        if (inputPassword != expectedPassword)
        {
            return false;
        }
        // Check if the password contains at least:
        // 1 uppercase letter, 1 lowercase letter, 1 special character, 1 number, and is at least 8 characters long
        bool hasUpperCase = Regex.IsMatch(inputPassword, @"[A-Z]");
        bool hasLowerCase = Regex.IsMatch(inputPassword, @"[a-z]");
        bool hasSpecialChar = Regex.IsMatch(inputPassword, @"[!@#$%^&*(),.?""{}|<>]");
        bool hasNumber = Regex.IsMatch(inputPassword, @"\d");
        bool hasValidLength = inputPassword.Length >= 8;

        if (hasUpperCase && hasLowerCase && hasSpecialChar && hasNumber && hasValidLength)
        {
          
            return true;
        }
        else
        {
            return false;
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
       
        Login();
    }


    public void Login()
    {
        
        if (Valid())
        {
            Session["Location"] = "Chennai";
            if (Session["Location"].ToString() == "Chennai")
            {
                Session["LotNoMaxLength"] = "11";
                Session["AllotededMaxLength"] = 3;
                Session["AllotededQty"] = 50;
                Session["LotNoFormat"] = "0001";
                Session["WaxNoMaxLength"] = 8;

                Session["CurrentYear"] = System.DateTime.Now.ToString("yy");
                Session["CurrentMonth"] = System.DateTime.Now.ToString("MM");
            }
            else if (Session["Location"].ToString() == "Pondicherry")
            {
                Session["LotNoMaxLength"] = "11";
                Session["AllotededMaxLength"] = 2;
                Session["AllotededQty"] = 50;
                Session["LotNoFormat"] = "0001";
                Session["WaxNoMaxLength"] = 6;

                Session["CurrentYear"] = System.DateTime.Now.ToString("yy");
                Session["CurrentMonth"] = System.DateTime.Now.ToString("MM");
            }
            if (username.Value == "admin" || username.Value == "ADMIN")
            {
                Session["up"] = 1;
                //Iswarya -- Concurrent login Validation 


                //var userLogin = db.Logins
                //.FirstOrDefault(x => x.LoginName == username.Value && x.Password == password.Value);

                //if (userLogin != null)
                //{
                //    userLogin.Login_Status = 1;

                //    db.SubmitChanges();
                //}

                Response.Redirect("BtchforMould.aspx");
            }
            else
            {
                Session["up"] = 2;
                //Iswarya -- Concurrent login Validation 

                //var userLogin = db.Logins
                //.FirstOrDefault(x => x.LoginName == username.Value && x.Password == password.Value);

                //if (userLogin != null)
                //{
                //    userLogin.Login_Status = 1;

                //    db.SubmitChanges();
                //}

                Response.Redirect("BtchforMould.aspx");

            }
        }
    }

}
