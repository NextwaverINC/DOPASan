﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace DOPAScan.DOPAGun_WS {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    using System.Data;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="GRB_WebServiceSoap", Namespace="http://tempuri.org/")]
    public partial class GRB_WebService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GetBookOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetPageOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetPageVersionOperationCompleted;
        
        private System.Threading.SendOrPostCallback SaveImagePageOperationCompleted;
        
        private System.Threading.SendOrPostCallback UserAuthOperationCompleted;
        
        private System.Threading.SendOrPostCallback getimgOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetCurrentImagePageOperationCompleted;
        
        private System.Threading.SendOrPostCallback EditPathImgOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public GRB_WebService() {
            this.Url = global::DOPAScan.Properties.Settings.Default.DOPAScan_DOPAGun_WS_GRB_WebService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event GetBookCompletedEventHandler GetBookCompleted;
        
        /// <remarks/>
        public event GetPageCompletedEventHandler GetPageCompleted;
        
        /// <remarks/>
        public event GetPageVersionCompletedEventHandler GetPageVersionCompleted;
        
        /// <remarks/>
        public event SaveImagePageCompletedEventHandler SaveImagePageCompleted;
        
        /// <remarks/>
        public event UserAuthCompletedEventHandler UserAuthCompleted;
        
        /// <remarks/>
        public event getimgCompletedEventHandler getimgCompleted;
        
        /// <remarks/>
        public event GetCurrentImagePageCompletedEventHandler GetCurrentImagePageCompleted;
        
        /// <remarks/>
        public event EditPathImgCompletedEventHandler EditPathImgCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetBook", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataTable GetBook(int BookNo) {
            object[] results = this.Invoke("GetBook", new object[] {
                        BookNo});
            return ((System.Data.DataTable)(results[0]));
        }
        
        /// <remarks/>
        public void GetBookAsync(int BookNo) {
            this.GetBookAsync(BookNo, null);
        }
        
        /// <remarks/>
        public void GetBookAsync(int BookNo, object userState) {
            if ((this.GetBookOperationCompleted == null)) {
                this.GetBookOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetBookOperationCompleted);
            }
            this.InvokeAsync("GetBook", new object[] {
                        BookNo}, this.GetBookOperationCompleted, userState);
        }
        
        private void OnGetBookOperationCompleted(object arg) {
            if ((this.GetBookCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetBookCompleted(this, new GetBookCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetPage", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataTable GetPage(int BookNo, int PageNo) {
            object[] results = this.Invoke("GetPage", new object[] {
                        BookNo,
                        PageNo});
            return ((System.Data.DataTable)(results[0]));
        }
        
        /// <remarks/>
        public void GetPageAsync(int BookNo, int PageNo) {
            this.GetPageAsync(BookNo, PageNo, null);
        }
        
        /// <remarks/>
        public void GetPageAsync(int BookNo, int PageNo, object userState) {
            if ((this.GetPageOperationCompleted == null)) {
                this.GetPageOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetPageOperationCompleted);
            }
            this.InvokeAsync("GetPage", new object[] {
                        BookNo,
                        PageNo}, this.GetPageOperationCompleted, userState);
        }
        
        private void OnGetPageOperationCompleted(object arg) {
            if ((this.GetPageCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetPageCompleted(this, new GetPageCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetPageVersion", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataTable GetPageVersion(int BookNo, int PageNo, int Version) {
            object[] results = this.Invoke("GetPageVersion", new object[] {
                        BookNo,
                        PageNo,
                        Version});
            return ((System.Data.DataTable)(results[0]));
        }
        
        /// <remarks/>
        public void GetPageVersionAsync(int BookNo, int PageNo, int Version) {
            this.GetPageVersionAsync(BookNo, PageNo, Version, null);
        }
        
        /// <remarks/>
        public void GetPageVersionAsync(int BookNo, int PageNo, int Version, object userState) {
            if ((this.GetPageVersionOperationCompleted == null)) {
                this.GetPageVersionOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetPageVersionOperationCompleted);
            }
            this.InvokeAsync("GetPageVersion", new object[] {
                        BookNo,
                        PageNo,
                        Version}, this.GetPageVersionOperationCompleted, userState);
        }
        
        private void OnGetPageVersionOperationCompleted(object arg) {
            if ((this.GetPageVersionCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetPageVersionCompleted(this, new GetPageVersionCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SaveImagePage", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool SaveImagePage(int BookNo, int PageNo, int Version, string ImgURL, string UserName, [System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary")] byte[] imageByte) {
            object[] results = this.Invoke("SaveImagePage", new object[] {
                        BookNo,
                        PageNo,
                        Version,
                        ImgURL,
                        UserName,
                        imageByte});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void SaveImagePageAsync(int BookNo, int PageNo, int Version, string ImgURL, string UserName, byte[] imageByte) {
            this.SaveImagePageAsync(BookNo, PageNo, Version, ImgURL, UserName, imageByte, null);
        }
        
        /// <remarks/>
        public void SaveImagePageAsync(int BookNo, int PageNo, int Version, string ImgURL, string UserName, byte[] imageByte, object userState) {
            if ((this.SaveImagePageOperationCompleted == null)) {
                this.SaveImagePageOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSaveImagePageOperationCompleted);
            }
            this.InvokeAsync("SaveImagePage", new object[] {
                        BookNo,
                        PageNo,
                        Version,
                        ImgURL,
                        UserName,
                        imageByte}, this.SaveImagePageOperationCompleted, userState);
        }
        
        private void OnSaveImagePageOperationCompleted(object arg) {
            if ((this.SaveImagePageCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SaveImagePageCompleted(this, new SaveImagePageCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/UserAuth", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataTable UserAuth(string UserName, string Password) {
            object[] results = this.Invoke("UserAuth", new object[] {
                        UserName,
                        Password});
            return ((System.Data.DataTable)(results[0]));
        }
        
        /// <remarks/>
        public void UserAuthAsync(string UserName, string Password) {
            this.UserAuthAsync(UserName, Password, null);
        }
        
        /// <remarks/>
        public void UserAuthAsync(string UserName, string Password, object userState) {
            if ((this.UserAuthOperationCompleted == null)) {
                this.UserAuthOperationCompleted = new System.Threading.SendOrPostCallback(this.OnUserAuthOperationCompleted);
            }
            this.InvokeAsync("UserAuth", new object[] {
                        UserName,
                        Password}, this.UserAuthOperationCompleted, userState);
        }
        
        private void OnUserAuthOperationCompleted(object arg) {
            if ((this.UserAuthCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.UserAuthCompleted(this, new UserAuthCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/getimg", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary")]
        public byte[] getimg(string pathImg) {
            object[] results = this.Invoke("getimg", new object[] {
                        pathImg});
            return ((byte[])(results[0]));
        }
        
        /// <remarks/>
        public void getimgAsync(string pathImg) {
            this.getimgAsync(pathImg, null);
        }
        
        /// <remarks/>
        public void getimgAsync(string pathImg, object userState) {
            if ((this.getimgOperationCompleted == null)) {
                this.getimgOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetimgOperationCompleted);
            }
            this.InvokeAsync("getimg", new object[] {
                        pathImg}, this.getimgOperationCompleted, userState);
        }
        
        private void OngetimgOperationCompleted(object arg) {
            if ((this.getimgCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getimgCompleted(this, new getimgCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetCurrentImagePage", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary")]
        public byte[] GetCurrentImagePage(int BookNo, int PageNo) {
            object[] results = this.Invoke("GetCurrentImagePage", new object[] {
                        BookNo,
                        PageNo});
            return ((byte[])(results[0]));
        }
        
        /// <remarks/>
        public void GetCurrentImagePageAsync(int BookNo, int PageNo) {
            this.GetCurrentImagePageAsync(BookNo, PageNo, null);
        }
        
        /// <remarks/>
        public void GetCurrentImagePageAsync(int BookNo, int PageNo, object userState) {
            if ((this.GetCurrentImagePageOperationCompleted == null)) {
                this.GetCurrentImagePageOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetCurrentImagePageOperationCompleted);
            }
            this.InvokeAsync("GetCurrentImagePage", new object[] {
                        BookNo,
                        PageNo}, this.GetCurrentImagePageOperationCompleted, userState);
        }
        
        private void OnGetCurrentImagePageOperationCompleted(object arg) {
            if ((this.GetCurrentImagePageCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetCurrentImagePageCompleted(this, new GetCurrentImagePageCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/EditPathImg", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool EditPathImg(int bookno) {
            object[] results = this.Invoke("EditPathImg", new object[] {
                        bookno});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void EditPathImgAsync(int bookno) {
            this.EditPathImgAsync(bookno, null);
        }
        
        /// <remarks/>
        public void EditPathImgAsync(int bookno, object userState) {
            if ((this.EditPathImgOperationCompleted == null)) {
                this.EditPathImgOperationCompleted = new System.Threading.SendOrPostCallback(this.OnEditPathImgOperationCompleted);
            }
            this.InvokeAsync("EditPathImg", new object[] {
                        bookno}, this.EditPathImgOperationCompleted, userState);
        }
        
        private void OnEditPathImgOperationCompleted(object arg) {
            if ((this.EditPathImgCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.EditPathImgCompleted(this, new EditPathImgCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void GetBookCompletedEventHandler(object sender, GetBookCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetBookCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetBookCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataTable Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataTable)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void GetPageCompletedEventHandler(object sender, GetPageCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetPageCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetPageCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataTable Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataTable)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void GetPageVersionCompletedEventHandler(object sender, GetPageVersionCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetPageVersionCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetPageVersionCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataTable Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataTable)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void SaveImagePageCompletedEventHandler(object sender, SaveImagePageCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SaveImagePageCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SaveImagePageCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void UserAuthCompletedEventHandler(object sender, UserAuthCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class UserAuthCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal UserAuthCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataTable Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataTable)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void getimgCompletedEventHandler(object sender, getimgCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getimgCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getimgCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public byte[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((byte[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void GetCurrentImagePageCompletedEventHandler(object sender, GetCurrentImagePageCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetCurrentImagePageCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetCurrentImagePageCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public byte[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((byte[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void EditPathImgCompletedEventHandler(object sender, EditPathImgCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class EditPathImgCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal EditPathImgCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591