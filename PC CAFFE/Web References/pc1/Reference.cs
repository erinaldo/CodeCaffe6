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

namespace PCPOS.pc1 {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    using System.Data;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="konektorSoap", Namespace="http://tempuri.org/")]
    public partial class konektor : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback HelloWorldOperationCompleted;
        
        private System.Threading.SendOrPostCallback PostaviSlikeOperationCompleted;
        
        private System.Threading.SendOrPostCallback PostaviSlikeCredentialsOperationCompleted;
        
        private System.Threading.SendOrPostCallback WebUrlOperationCompleted;
        
        private System.Threading.SendOrPostCallback BazaExecuteOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetDatasetOperationCompleted;
        
        private System.Threading.SendOrPostCallback ExecuteOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public konektor() {
            this.Url = global::PCPOS.Properties.Settings.Default.PC_POS_pc1_konektor;
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
        public event HelloWorldCompletedEventHandler HelloWorldCompleted;
        
        /// <remarks/>
        public event PostaviSlikeCompletedEventHandler PostaviSlikeCompleted;
        
        /// <remarks/>
        public event PostaviSlikeCredentialsCompletedEventHandler PostaviSlikeCredentialsCompleted;
        
        /// <remarks/>
        public event WebUrlCompletedEventHandler WebUrlCompleted;
        
        /// <remarks/>
        public event BazaExecuteCompletedEventHandler BazaExecuteCompleted;
        
        /// <remarks/>
        public event GetDatasetCompletedEventHandler GetDatasetCompleted;
        
        /// <remarks/>
        public event ExecuteCompletedEventHandler ExecuteCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/HelloWorld", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string HelloWorld() {
            object[] results = this.Invoke("HelloWorld", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void HelloWorldAsync() {
            this.HelloWorldAsync(null);
        }
        
        /// <remarks/>
        public void HelloWorldAsync(object userState) {
            if ((this.HelloWorldOperationCompleted == null)) {
                this.HelloWorldOperationCompleted = new System.Threading.SendOrPostCallback(this.OnHelloWorldOperationCompleted);
            }
            this.InvokeAsync("HelloWorld", new object[0], this.HelloWorldOperationCompleted, userState);
        }
        
        private void OnHelloWorldOperationCompleted(object arg) {
            if ((this.HelloWorldCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.HelloWorldCompleted(this, new HelloWorldCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/PostaviSlike", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string PostaviSlike() {
            object[] results = this.Invoke("PostaviSlike", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void PostaviSlikeAsync() {
            this.PostaviSlikeAsync(null);
        }
        
        /// <remarks/>
        public void PostaviSlikeAsync(object userState) {
            if ((this.PostaviSlikeOperationCompleted == null)) {
                this.PostaviSlikeOperationCompleted = new System.Threading.SendOrPostCallback(this.OnPostaviSlikeOperationCompleted);
            }
            this.InvokeAsync("PostaviSlike", new object[0], this.PostaviSlikeOperationCompleted, userState);
        }
        
        private void OnPostaviSlikeOperationCompleted(object arg) {
            if ((this.PostaviSlikeCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.PostaviSlikeCompleted(this, new PostaviSlikeCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/PostaviSlikeCredentials", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string PostaviSlikeCredentials(string user, string pass, string id_dobavljac) {
            object[] results = this.Invoke("PostaviSlikeCredentials", new object[] {
                        user,
                        pass,
                        id_dobavljac});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void PostaviSlikeCredentialsAsync(string user, string pass, string id_dobavljac) {
            this.PostaviSlikeCredentialsAsync(user, pass, id_dobavljac, null);
        }
        
        /// <remarks/>
        public void PostaviSlikeCredentialsAsync(string user, string pass, string id_dobavljac, object userState) {
            if ((this.PostaviSlikeCredentialsOperationCompleted == null)) {
                this.PostaviSlikeCredentialsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnPostaviSlikeCredentialsOperationCompleted);
            }
            this.InvokeAsync("PostaviSlikeCredentials", new object[] {
                        user,
                        pass,
                        id_dobavljac}, this.PostaviSlikeCredentialsOperationCompleted, userState);
        }
        
        private void OnPostaviSlikeCredentialsOperationCompleted(object arg) {
            if ((this.PostaviSlikeCredentialsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.PostaviSlikeCredentialsCompleted(this, new PostaviSlikeCredentialsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/WebUrl", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string WebUrl() {
            object[] results = this.Invoke("WebUrl", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void WebUrlAsync() {
            this.WebUrlAsync(null);
        }
        
        /// <remarks/>
        public void WebUrlAsync(object userState) {
            if ((this.WebUrlOperationCompleted == null)) {
                this.WebUrlOperationCompleted = new System.Threading.SendOrPostCallback(this.OnWebUrlOperationCompleted);
            }
            this.InvokeAsync("WebUrl", new object[0], this.WebUrlOperationCompleted, userState);
        }
        
        private void OnWebUrlOperationCompleted(object arg) {
            if ((this.WebUrlCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.WebUrlCompleted(this, new WebUrlCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/BazaExecute", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string BazaExecute(string xml, string user, string pass) {
            object[] results = this.Invoke("BazaExecute", new object[] {
                        xml,
                        user,
                        pass});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void BazaExecuteAsync(string xml, string user, string pass) {
            this.BazaExecuteAsync(xml, user, pass, null);
        }
        
        /// <remarks/>
        public void BazaExecuteAsync(string xml, string user, string pass, object userState) {
            if ((this.BazaExecuteOperationCompleted == null)) {
                this.BazaExecuteOperationCompleted = new System.Threading.SendOrPostCallback(this.OnBazaExecuteOperationCompleted);
            }
            this.InvokeAsync("BazaExecute", new object[] {
                        xml,
                        user,
                        pass}, this.BazaExecuteOperationCompleted, userState);
        }
        
        private void OnBazaExecuteOperationCompleted(object arg) {
            if ((this.BazaExecuteCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.BazaExecuteCompleted(this, new BazaExecuteCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetDataset", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataSet GetDataset(string query, string table_name, string user, string pass) {
            object[] results = this.Invoke("GetDataset", new object[] {
                        query,
                        table_name,
                        user,
                        pass});
            return ((System.Data.DataSet)(results[0]));
        }
        
        /// <remarks/>
        public void GetDatasetAsync(string query, string table_name, string user, string pass) {
            this.GetDatasetAsync(query, table_name, user, pass, null);
        }
        
        /// <remarks/>
        public void GetDatasetAsync(string query, string table_name, string user, string pass, object userState) {
            if ((this.GetDatasetOperationCompleted == null)) {
                this.GetDatasetOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetDatasetOperationCompleted);
            }
            this.InvokeAsync("GetDataset", new object[] {
                        query,
                        table_name,
                        user,
                        pass}, this.GetDatasetOperationCompleted, userState);
        }
        
        private void OnGetDatasetOperationCompleted(object arg) {
            if ((this.GetDatasetCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetDatasetCompleted(this, new GetDatasetCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Execute", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string Execute(string query, string user, string pass) {
            object[] results = this.Invoke("Execute", new object[] {
                        query,
                        user,
                        pass});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ExecuteAsync(string query, string user, string pass) {
            this.ExecuteAsync(query, user, pass, null);
        }
        
        /// <remarks/>
        public void ExecuteAsync(string query, string user, string pass, object userState) {
            if ((this.ExecuteOperationCompleted == null)) {
                this.ExecuteOperationCompleted = new System.Threading.SendOrPostCallback(this.OnExecuteOperationCompleted);
            }
            this.InvokeAsync("Execute", new object[] {
                        query,
                        user,
                        pass}, this.ExecuteOperationCompleted, userState);
        }
        
        private void OnExecuteOperationCompleted(object arg) {
            if ((this.ExecuteCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ExecuteCompleted(this, new ExecuteCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    public delegate void HelloWorldCompletedEventHandler(object sender, HelloWorldCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class HelloWorldCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal HelloWorldCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    public delegate void PostaviSlikeCompletedEventHandler(object sender, PostaviSlikeCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class PostaviSlikeCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal PostaviSlikeCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    public delegate void PostaviSlikeCredentialsCompletedEventHandler(object sender, PostaviSlikeCredentialsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class PostaviSlikeCredentialsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal PostaviSlikeCredentialsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    public delegate void WebUrlCompletedEventHandler(object sender, WebUrlCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class WebUrlCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal WebUrlCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    public delegate void BazaExecuteCompletedEventHandler(object sender, BazaExecuteCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class BazaExecuteCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal BazaExecuteCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    public delegate void GetDatasetCompletedEventHandler(object sender, GetDatasetCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetDatasetCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetDatasetCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataSet Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataSet)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    public delegate void ExecuteCompletedEventHandler(object sender, ExecuteCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ExecuteCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ExecuteCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591