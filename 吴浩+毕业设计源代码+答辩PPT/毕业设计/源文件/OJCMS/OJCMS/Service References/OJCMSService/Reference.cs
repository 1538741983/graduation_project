﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace OJCMS.OJCMSService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MenuDO", Namespace="http://schemas.datacontract.org/2004/07/OJCMS.Domain", IsReference=true)]
    [System.SerializableAttribute()]
    public partial class MenuDO : OJCMS.OJCMSService.EntityObject {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool DsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool Fg_sysField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private long IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<long> Id_perentField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string InnerCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NavigateUrlField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> NumField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TargetField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Code {
            get {
                return this.CodeField;
            }
            set {
                if ((object.ReferenceEquals(this.CodeField, value) != true)) {
                    this.CodeField = value;
                    this.RaisePropertyChanged("Code");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Ds {
            get {
                return this.DsField;
            }
            set {
                if ((this.DsField.Equals(value) != true)) {
                    this.DsField = value;
                    this.RaisePropertyChanged("Ds");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Fg_sys {
            get {
                return this.Fg_sysField;
            }
            set {
                if ((this.Fg_sysField.Equals(value) != true)) {
                    this.Fg_sysField = value;
                    this.RaisePropertyChanged("Fg_sys");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<long> Id_perent {
            get {
                return this.Id_perentField;
            }
            set {
                if ((this.Id_perentField.Equals(value) != true)) {
                    this.Id_perentField = value;
                    this.RaisePropertyChanged("Id_perent");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string InnerCode {
            get {
                return this.InnerCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.InnerCodeField, value) != true)) {
                    this.InnerCodeField = value;
                    this.RaisePropertyChanged("InnerCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string NavigateUrl {
            get {
                return this.NavigateUrlField;
            }
            set {
                if ((object.ReferenceEquals(this.NavigateUrlField, value) != true)) {
                    this.NavigateUrlField = value;
                    this.RaisePropertyChanged("NavigateUrl");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> Num {
            get {
                return this.NumField;
            }
            set {
                if ((this.NumField.Equals(value) != true)) {
                    this.NumField = value;
                    this.RaisePropertyChanged("Num");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Target {
            get {
                return this.TargetField;
            }
            set {
                if ((object.ReferenceEquals(this.TargetField, value) != true)) {
                    this.TargetField = value;
                    this.RaisePropertyChanged("Target");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="StructuralObject", Namespace="http://schemas.datacontract.org/2004/07/System.Data.Objects.DataClasses", IsReference=true)]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(OJCMS.OJCMSService.EntityObject))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(OJCMS.OJCMSService.MenuDO))]
    public partial class StructuralObject : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="EntityObject", Namespace="http://schemas.datacontract.org/2004/07/System.Data.Objects.DataClasses", IsReference=true)]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(OJCMS.OJCMSService.MenuDO))]
    public partial class EntityObject : OJCMS.OJCMSService.StructuralObject {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private OJCMS.OJCMSService.EntityKey EntityKeyField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public OJCMS.OJCMSService.EntityKey EntityKey {
            get {
                return this.EntityKeyField;
            }
            set {
                if ((object.ReferenceEquals(this.EntityKeyField, value) != true)) {
                    this.EntityKeyField = value;
                    this.RaisePropertyChanged("EntityKey");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="EntityKey", Namespace="http://schemas.datacontract.org/2004/07/System.Data", IsReference=true)]
    [System.SerializableAttribute()]
    public partial class EntityKey : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EntityContainerNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private OJCMS.OJCMSService.EntityKeyMember[] EntityKeyValuesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EntitySetNameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string EntityContainerName {
            get {
                return this.EntityContainerNameField;
            }
            set {
                if ((object.ReferenceEquals(this.EntityContainerNameField, value) != true)) {
                    this.EntityContainerNameField = value;
                    this.RaisePropertyChanged("EntityContainerName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public OJCMS.OJCMSService.EntityKeyMember[] EntityKeyValues {
            get {
                return this.EntityKeyValuesField;
            }
            set {
                if ((object.ReferenceEquals(this.EntityKeyValuesField, value) != true)) {
                    this.EntityKeyValuesField = value;
                    this.RaisePropertyChanged("EntityKeyValues");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string EntitySetName {
            get {
                return this.EntitySetNameField;
            }
            set {
                if ((object.ReferenceEquals(this.EntitySetNameField, value) != true)) {
                    this.EntitySetNameField = value;
                    this.RaisePropertyChanged("EntitySetName");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="EntityKeyMember", Namespace="http://schemas.datacontract.org/2004/07/System.Data")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(OJCMS.OJCMSService.EntityObject))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(OJCMS.OJCMSService.StructuralObject))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(OJCMS.OJCMSService.MenuDO[]))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(OJCMS.OJCMSService.MenuDO))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(OJCMS.OJCMSService.EntityKey))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(OJCMS.OJCMSService.EntityKeyMember[]))]
    public partial class EntityKeyMember : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string KeyField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private object ValueField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Key {
            get {
                return this.KeyField;
            }
            set {
                if ((object.ReferenceEquals(this.KeyField, value) != true)) {
                    this.KeyField = value;
                    this.RaisePropertyChanged("Key");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public object Value {
            get {
                return this.ValueField;
            }
            set {
                if ((object.ReferenceEquals(this.ValueField, value) != true)) {
                    this.ValueField = value;
                    this.RaisePropertyChanged("Value");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="OJCMSService.IOJCMSService")]
    public interface IOJCMSService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOJCMSService/DoWork", ReplyAction="http://tempuri.org/IOJCMSService/DoWorkResponse")]
        void DoWork();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOJCMSService/GetMenuList", ReplyAction="http://tempuri.org/IOJCMSService/GetMenuListResponse")]
        OJCMS.OJCMSService.MenuDO[] GetMenuList();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOJCMSService/DeleteMenuById", ReplyAction="http://tempuri.org/IOJCMSService/DeleteMenuByIdResponse")]
        bool DeleteMenuById(string menuId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOJCMSService/GetChildrenMenuList", ReplyAction="http://tempuri.org/IOJCMSService/GetChildrenMenuListResponse")]
        OJCMS.OJCMSService.MenuDO[] GetChildrenMenuList(long parentId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOJCMSService/GetMenuDoById", ReplyAction="http://tempuri.org/IOJCMSService/GetMenuDoByIdResponse")]
        OJCMS.OJCMSService.MenuDO GetMenuDoById(long id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOJCMSService/UpdateMenu", ReplyAction="http://tempuri.org/IOJCMSService/UpdateMenuResponse")]
        bool UpdateMenu(OJCMS.OJCMSService.MenuDO menu);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOJCMSService/AddMenu", ReplyAction="http://tempuri.org/IOJCMSService/AddMenuResponse")]
        bool AddMenu(OJCMS.OJCMSService.MenuDO menu);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IOJCMSServiceChannel : OJCMS.OJCMSService.IOJCMSService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class OJCMSServiceClient : System.ServiceModel.ClientBase<OJCMS.OJCMSService.IOJCMSService>, OJCMS.OJCMSService.IOJCMSService {
        
        public OJCMSServiceClient() {
        }
        
        public OJCMSServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public OJCMSServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OJCMSServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OJCMSServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void DoWork() {
            base.Channel.DoWork();
        }
        
        public OJCMS.OJCMSService.MenuDO[] GetMenuList() {
            return base.Channel.GetMenuList();
        }
        
        public bool DeleteMenuById(string menuId) {
            return base.Channel.DeleteMenuById(menuId);
        }
        
        public OJCMS.OJCMSService.MenuDO[] GetChildrenMenuList(long parentId) {
            return base.Channel.GetChildrenMenuList(parentId);
        }
        
        public OJCMS.OJCMSService.MenuDO GetMenuDoById(long id) {
            return base.Channel.GetMenuDoById(id);
        }
        
        public bool UpdateMenu(OJCMS.OJCMSService.MenuDO menu) {
            return base.Channel.UpdateMenu(menu);
        }
        
        public bool AddMenu(OJCMS.OJCMSService.MenuDO menu) {
            return base.Channel.AddMenu(menu);
        }
    }
}
