﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;



[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="MOULDING_ERP")]
public partial class IOL_ERPDataContext : System.Data.Linq.DataContext
{
	
	private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
	
  #region Extensibility Method Definitions
  partial void OnCreated();
  partial void InsertMoulding_Rejection(Moulding_Rejection instance);
  partial void UpdateMoulding_Rejection(Moulding_Rejection instance);
  partial void DeleteMoulding_Rejection(Moulding_Rejection instance);
  #endregion
	
	public IOL_ERPDataContext() : 
			base(global::System.Configuration.ConfigurationManager.ConnectionStrings["MOULDING_ERPConnectionString"].ConnectionString, mappingSource)
	{
		OnCreated();
	}
	
	public IOL_ERPDataContext(string connection) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public IOL_ERPDataContext(System.Data.IDbConnection connection) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public IOL_ERPDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public IOL_ERPDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public System.Data.Linq.Table<Moulding_Rejection> Moulding_Rejections
	{
		get
		{
			return this.GetTable<Moulding_Rejection>();
		}
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Moulding_Rejection")]
public partial class Moulding_Rejection : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private long _id;
	
	private string _Solution_Id;
	
	private string _Reflot;
	
	private string _Model;
	
	private System.Nullable<decimal> _Power;
	
	private string _Process_code;
	
	private string _Process_Name;
	
	private System.Nullable<int> _Rec_Qty;
	
	private System.Nullable<int> _Acc_Qty;
	
	private System.Nullable<int> _Rej_Qty;
	
	private string _Created_Date;
	
	private string _Created_By;
	
	private string _Inspected_By;
	
	private System.Nullable<int> _flag;
	
	private string _Next_Process;
	
	private string _BMR_NO;
	
	private string _Created_User;
	
	private System.Nullable<System.DateTime> _Updated_Date;
	
	private string _Approved_by;
	
	private string _Machine_ID;
	
	private string _Volume;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(long value);
    partial void OnidChanged();
    partial void OnSolution_IdChanging(string value);
    partial void OnSolution_IdChanged();
    partial void OnReflotChanging(string value);
    partial void OnReflotChanged();
    partial void OnModelChanging(string value);
    partial void OnModelChanged();
    partial void OnPowerChanging(System.Nullable<decimal> value);
    partial void OnPowerChanged();
    partial void OnProcess_codeChanging(string value);
    partial void OnProcess_codeChanged();
    partial void OnProcess_NameChanging(string value);
    partial void OnProcess_NameChanged();
    partial void OnRec_QtyChanging(System.Nullable<int> value);
    partial void OnRec_QtyChanged();
    partial void OnAcc_QtyChanging(System.Nullable<int> value);
    partial void OnAcc_QtyChanged();
    partial void OnRej_QtyChanging(System.Nullable<int> value);
    partial void OnRej_QtyChanged();
    partial void OnCreated_DateChanging(string value);
    partial void OnCreated_DateChanged();
    partial void OnCreated_ByChanging(string value);
    partial void OnCreated_ByChanged();
    partial void OnInspected_ByChanging(string value);
    partial void OnInspected_ByChanged();
    partial void OnflagChanging(System.Nullable<int> value);
    partial void OnflagChanged();
    partial void OnNext_ProcessChanging(string value);
    partial void OnNext_ProcessChanged();
    partial void OnBMR_NOChanging(string value);
    partial void OnBMR_NOChanged();
    partial void OnCreated_UserChanging(string value);
    partial void OnCreated_UserChanged();
    partial void OnUpdated_DateChanging(System.Nullable<System.DateTime> value);
    partial void OnUpdated_DateChanged();
    partial void OnApproved_byChanging(string value);
    partial void OnApproved_byChanged();
    partial void OnMachine_IDChanging(string value);
    partial void OnMachine_IDChanged();
    partial void OnVolumeChanging(string value);
    partial void OnVolumeChanged();
    #endregion
	
	public Moulding_Rejection()
	{
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
	public long id
	{
		get
		{
			return this._id;
		}
		set
		{
			if ((this._id != value))
			{
				this.OnidChanging(value);
				this.SendPropertyChanging();
				this._id = value;
				this.SendPropertyChanged("id");
				this.OnidChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Solution_Id", DbType="NVarChar(50)")]
	public string Solution_Id
	{
		get
		{
			return this._Solution_Id;
		}
		set
		{
			if ((this._Solution_Id != value))
			{
				this.OnSolution_IdChanging(value);
				this.SendPropertyChanging();
				this._Solution_Id = value;
				this.SendPropertyChanged("Solution_Id");
				this.OnSolution_IdChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Reflot", DbType="NVarChar(20)")]
	public string Reflot
	{
		get
		{
			return this._Reflot;
		}
		set
		{
			if ((this._Reflot != value))
			{
				this.OnReflotChanging(value);
				this.SendPropertyChanging();
				this._Reflot = value;
				this.SendPropertyChanged("Reflot");
				this.OnReflotChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Model", DbType="NVarChar(50)")]
	public string Model
	{
		get
		{
			return this._Model;
		}
		set
		{
			if ((this._Model != value))
			{
				this.OnModelChanging(value);
				this.SendPropertyChanging();
				this._Model = value;
				this.SendPropertyChanged("Model");
				this.OnModelChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Power", DbType="Decimal(18,2)")]
	public System.Nullable<decimal> Power
	{
		get
		{
			return this._Power;
		}
		set
		{
			if ((this._Power != value))
			{
				this.OnPowerChanging(value);
				this.SendPropertyChanging();
				this._Power = value;
				this.SendPropertyChanged("Power");
				this.OnPowerChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Process_code", DbType="NVarChar(50)")]
	public string Process_code
	{
		get
		{
			return this._Process_code;
		}
		set
		{
			if ((this._Process_code != value))
			{
				this.OnProcess_codeChanging(value);
				this.SendPropertyChanging();
				this._Process_code = value;
				this.SendPropertyChanged("Process_code");
				this.OnProcess_codeChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Process_Name", DbType="NVarChar(200)")]
	public string Process_Name
	{
		get
		{
			return this._Process_Name;
		}
		set
		{
			if ((this._Process_Name != value))
			{
				this.OnProcess_NameChanging(value);
				this.SendPropertyChanging();
				this._Process_Name = value;
				this.SendPropertyChanged("Process_Name");
				this.OnProcess_NameChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Rec_Qty", DbType="Int")]
	public System.Nullable<int> Rec_Qty
	{
		get
		{
			return this._Rec_Qty;
		}
		set
		{
			if ((this._Rec_Qty != value))
			{
				this.OnRec_QtyChanging(value);
				this.SendPropertyChanging();
				this._Rec_Qty = value;
				this.SendPropertyChanged("Rec_Qty");
				this.OnRec_QtyChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Acc_Qty", DbType="Int")]
	public System.Nullable<int> Acc_Qty
	{
		get
		{
			return this._Acc_Qty;
		}
		set
		{
			if ((this._Acc_Qty != value))
			{
				this.OnAcc_QtyChanging(value);
				this.SendPropertyChanging();
				this._Acc_Qty = value;
				this.SendPropertyChanged("Acc_Qty");
				this.OnAcc_QtyChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Rej_Qty", DbType="Int")]
	public System.Nullable<int> Rej_Qty
	{
		get
		{
			return this._Rej_Qty;
		}
		set
		{
			if ((this._Rej_Qty != value))
			{
				this.OnRej_QtyChanging(value);
				this.SendPropertyChanging();
				this._Rej_Qty = value;
				this.SendPropertyChanged("Rej_Qty");
				this.OnRej_QtyChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Created_Date", DbType="NChar(50)")]
	public string Created_Date
	{
		get
		{
			return this._Created_Date;
		}
		set
		{
			if ((this._Created_Date != value))
			{
				this.OnCreated_DateChanging(value);
				this.SendPropertyChanging();
				this._Created_Date = value;
				this.SendPropertyChanged("Created_Date");
				this.OnCreated_DateChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Created_By", DbType="NVarChar(50)")]
	public string Created_By
	{
		get
		{
			return this._Created_By;
		}
		set
		{
			if ((this._Created_By != value))
			{
				this.OnCreated_ByChanging(value);
				this.SendPropertyChanging();
				this._Created_By = value;
				this.SendPropertyChanged("Created_By");
				this.OnCreated_ByChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Inspected_By", DbType="NVarChar(50)")]
	public string Inspected_By
	{
		get
		{
			return this._Inspected_By;
		}
		set
		{
			if ((this._Inspected_By != value))
			{
				this.OnInspected_ByChanging(value);
				this.SendPropertyChanging();
				this._Inspected_By = value;
				this.SendPropertyChanged("Inspected_By");
				this.OnInspected_ByChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_flag", DbType="Int")]
	public System.Nullable<int> flag
	{
		get
		{
			return this._flag;
		}
		set
		{
			if ((this._flag != value))
			{
				this.OnflagChanging(value);
				this.SendPropertyChanging();
				this._flag = value;
				this.SendPropertyChanged("flag");
				this.OnflagChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Next_Process", DbType="NVarChar(50)")]
	public string Next_Process
	{
		get
		{
			return this._Next_Process;
		}
		set
		{
			if ((this._Next_Process != value))
			{
				this.OnNext_ProcessChanging(value);
				this.SendPropertyChanging();
				this._Next_Process = value;
				this.SendPropertyChanged("Next_Process");
				this.OnNext_ProcessChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BMR_NO", DbType="NVarChar(100)")]
	public string BMR_NO
	{
		get
		{
			return this._BMR_NO;
		}
		set
		{
			if ((this._BMR_NO != value))
			{
				this.OnBMR_NOChanging(value);
				this.SendPropertyChanging();
				this._BMR_NO = value;
				this.SendPropertyChanged("BMR_NO");
				this.OnBMR_NOChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Created_User", DbType="VarChar(50)")]
	public string Created_User
	{
		get
		{
			return this._Created_User;
		}
		set
		{
			if ((this._Created_User != value))
			{
				this.OnCreated_UserChanging(value);
				this.SendPropertyChanging();
				this._Created_User = value;
				this.SendPropertyChanged("Created_User");
				this.OnCreated_UserChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Updated_Date", DbType="DateTime")]
	public System.Nullable<System.DateTime> Updated_Date
	{
		get
		{
			return this._Updated_Date;
		}
		set
		{
			if ((this._Updated_Date != value))
			{
				this.OnUpdated_DateChanging(value);
				this.SendPropertyChanging();
				this._Updated_Date = value;
				this.SendPropertyChanged("Updated_Date");
				this.OnUpdated_DateChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Approved_by", DbType="VarChar(50)")]
	public string Approved_by
	{
		get
		{
			return this._Approved_by;
		}
		set
		{
			if ((this._Approved_by != value))
			{
				this.OnApproved_byChanging(value);
				this.SendPropertyChanging();
				this._Approved_by = value;
				this.SendPropertyChanged("Approved_by");
				this.OnApproved_byChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Machine_ID", DbType="NVarChar(50)")]
	public string Machine_ID
	{
		get
		{
			return this._Machine_ID;
		}
		set
		{
			if ((this._Machine_ID != value))
			{
				this.OnMachine_IDChanging(value);
				this.SendPropertyChanging();
				this._Machine_ID = value;
				this.SendPropertyChanged("Machine_ID");
				this.OnMachine_IDChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Volume", DbType="NVarChar(20)")]
	public string Volume
	{
		get
		{
			return this._Volume;
		}
		set
		{
			if ((this._Volume != value))
			{
				this.OnVolumeChanging(value);
				this.SendPropertyChanging();
				this._Volume = value;
				this.SendPropertyChanged("Volume");
				this.OnVolumeChanged();
			}
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
#pragma warning restore 1591
