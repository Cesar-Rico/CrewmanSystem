﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CrewmanSystem.PromocionWS {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://services.CrewmanSystem.pucp.edu.pe/", ConfigurationName="PromocionWS.PromocionWS")]
    public interface PromocionWS {
        
        // CODEGEN: El parámetro 'return' requiere información adicional de esquema que no se puede capturar con el modo de parámetros. El atributo específico es 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="http://services.CrewmanSystem.pucp.edu.pe/PromocionWS/listarPromocionsRequest", ReplyAction="http://services.CrewmanSystem.pucp.edu.pe/PromocionWS/listarPromocionsResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        CrewmanSystem.PromocionWS.listarPromocionsResponse listarPromocions(CrewmanSystem.PromocionWS.listarPromocionsRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://services.CrewmanSystem.pucp.edu.pe/PromocionWS/listarPromocionsRequest", ReplyAction="http://services.CrewmanSystem.pucp.edu.pe/PromocionWS/listarPromocionsResponse")]
        System.Threading.Tasks.Task<CrewmanSystem.PromocionWS.listarPromocionsResponse> listarPromocionsAsync(CrewmanSystem.PromocionWS.listarPromocionsRequest request);
        
        // CODEGEN: El parámetro 'return' requiere información adicional de esquema que no se puede capturar con el modo de parámetros. El atributo específico es 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="http://services.CrewmanSystem.pucp.edu.pe/PromocionWS/actualizarPromocionRequest", ReplyAction="http://services.CrewmanSystem.pucp.edu.pe/PromocionWS/actualizarPromocionResponse" +
            "")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        CrewmanSystem.PromocionWS.actualizarPromocionResponse actualizarPromocion(CrewmanSystem.PromocionWS.actualizarPromocionRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://services.CrewmanSystem.pucp.edu.pe/PromocionWS/actualizarPromocionRequest", ReplyAction="http://services.CrewmanSystem.pucp.edu.pe/PromocionWS/actualizarPromocionResponse" +
            "")]
        System.Threading.Tasks.Task<CrewmanSystem.PromocionWS.actualizarPromocionResponse> actualizarPromocionAsync(CrewmanSystem.PromocionWS.actualizarPromocionRequest request);
        
        // CODEGEN: El parámetro 'return' requiere información adicional de esquema que no se puede capturar con el modo de parámetros. El atributo específico es 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="http://services.CrewmanSystem.pucp.edu.pe/PromocionWS/eliminarPromocionRequest", ReplyAction="http://services.CrewmanSystem.pucp.edu.pe/PromocionWS/eliminarPromocionResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        CrewmanSystem.PromocionWS.eliminarPromocionResponse eliminarPromocion(CrewmanSystem.PromocionWS.eliminarPromocionRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://services.CrewmanSystem.pucp.edu.pe/PromocionWS/eliminarPromocionRequest", ReplyAction="http://services.CrewmanSystem.pucp.edu.pe/PromocionWS/eliminarPromocionResponse")]
        System.Threading.Tasks.Task<CrewmanSystem.PromocionWS.eliminarPromocionResponse> eliminarPromocionAsync(CrewmanSystem.PromocionWS.eliminarPromocionRequest request);
        
        // CODEGEN: El parámetro 'return' requiere información adicional de esquema que no se puede capturar con el modo de parámetros. El atributo específico es 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="http://services.CrewmanSystem.pucp.edu.pe/PromocionWS/insertarPromocionRequest", ReplyAction="http://services.CrewmanSystem.pucp.edu.pe/PromocionWS/insertarPromocionResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        CrewmanSystem.PromocionWS.insertarPromocionResponse insertarPromocion(CrewmanSystem.PromocionWS.insertarPromocionRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://services.CrewmanSystem.pucp.edu.pe/PromocionWS/insertarPromocionRequest", ReplyAction="http://services.CrewmanSystem.pucp.edu.pe/PromocionWS/insertarPromocionResponse")]
        System.Threading.Tasks.Task<CrewmanSystem.PromocionWS.insertarPromocionResponse> insertarPromocionAsync(CrewmanSystem.PromocionWS.insertarPromocionRequest request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://services.CrewmanSystem.pucp.edu.pe/")]
    public partial class promocion : object, System.ComponentModel.INotifyPropertyChanged {
        
        private bool activoField;
        
        private string descripcionField;
        
        private System.DateTime fechaFinField;
        
        private bool fechaFinFieldSpecified;
        
        private System.DateTime fechaInicioField;
        
        private bool fechaInicioFieldSpecified;
        
        private int idPromocionField;
        
        private string nombreField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public bool activo {
            get {
                return this.activoField;
            }
            set {
                this.activoField = value;
                this.RaisePropertyChanged("activo");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string descripcion {
            get {
                return this.descripcionField;
            }
            set {
                this.descripcionField = value;
                this.RaisePropertyChanged("descripcion");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public System.DateTime fechaFin {
            get {
                return this.fechaFinField;
            }
            set {
                this.fechaFinField = value;
                this.RaisePropertyChanged("fechaFin");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool fechaFinSpecified {
            get {
                return this.fechaFinFieldSpecified;
            }
            set {
                this.fechaFinFieldSpecified = value;
                this.RaisePropertyChanged("fechaFinSpecified");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=3)]
        public System.DateTime fechaInicio {
            get {
                return this.fechaInicioField;
            }
            set {
                this.fechaInicioField = value;
                this.RaisePropertyChanged("fechaInicio");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool fechaInicioSpecified {
            get {
                return this.fechaInicioFieldSpecified;
            }
            set {
                this.fechaInicioFieldSpecified = value;
                this.RaisePropertyChanged("fechaInicioSpecified");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=4)]
        public int idPromocion {
            get {
                return this.idPromocionField;
            }
            set {
                this.idPromocionField = value;
                this.RaisePropertyChanged("idPromocion");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=5)]
        public string nombre {
            get {
                return this.nombreField;
            }
            set {
                this.nombreField = value;
                this.RaisePropertyChanged("nombre");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="listarPromocions", WrapperNamespace="http://services.CrewmanSystem.pucp.edu.pe/", IsWrapped=true)]
    public partial class listarPromocionsRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://services.CrewmanSystem.pucp.edu.pe/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string nombre;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://services.CrewmanSystem.pucp.edu.pe/", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public System.DateTime fechaIni;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://services.CrewmanSystem.pucp.edu.pe/", Order=2)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public System.DateTime fechaFin;
        
        public listarPromocionsRequest() {
        }
        
        public listarPromocionsRequest(string nombre, System.DateTime fechaIni, System.DateTime fechaFin) {
            this.nombre = nombre;
            this.fechaIni = fechaIni;
            this.fechaFin = fechaFin;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="listarPromocionsResponse", WrapperNamespace="http://services.CrewmanSystem.pucp.edu.pe/", IsWrapped=true)]
    public partial class listarPromocionsResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://services.CrewmanSystem.pucp.edu.pe/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public CrewmanSystem.PromocionWS.promocion[] @return;
        
        public listarPromocionsResponse() {
        }
        
        public listarPromocionsResponse(CrewmanSystem.PromocionWS.promocion[] @return) {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="actualizarPromocion", WrapperNamespace="http://services.CrewmanSystem.pucp.edu.pe/", IsWrapped=true)]
    public partial class actualizarPromocionRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://services.CrewmanSystem.pucp.edu.pe/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public CrewmanSystem.PromocionWS.promocion promocion;
        
        public actualizarPromocionRequest() {
        }
        
        public actualizarPromocionRequest(CrewmanSystem.PromocionWS.promocion promocion) {
            this.promocion = promocion;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="actualizarPromocionResponse", WrapperNamespace="http://services.CrewmanSystem.pucp.edu.pe/", IsWrapped=true)]
    public partial class actualizarPromocionResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://services.CrewmanSystem.pucp.edu.pe/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int @return;
        
        public actualizarPromocionResponse() {
        }
        
        public actualizarPromocionResponse(int @return) {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="eliminarPromocion", WrapperNamespace="http://services.CrewmanSystem.pucp.edu.pe/", IsWrapped=true)]
    public partial class eliminarPromocionRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://services.CrewmanSystem.pucp.edu.pe/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int idPromocion;
        
        public eliminarPromocionRequest() {
        }
        
        public eliminarPromocionRequest(int idPromocion) {
            this.idPromocion = idPromocion;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="eliminarPromocionResponse", WrapperNamespace="http://services.CrewmanSystem.pucp.edu.pe/", IsWrapped=true)]
    public partial class eliminarPromocionResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://services.CrewmanSystem.pucp.edu.pe/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int @return;
        
        public eliminarPromocionResponse() {
        }
        
        public eliminarPromocionResponse(int @return) {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="insertarPromocion", WrapperNamespace="http://services.CrewmanSystem.pucp.edu.pe/", IsWrapped=true)]
    public partial class insertarPromocionRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://services.CrewmanSystem.pucp.edu.pe/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public CrewmanSystem.PromocionWS.promocion promocion;
        
        public insertarPromocionRequest() {
        }
        
        public insertarPromocionRequest(CrewmanSystem.PromocionWS.promocion promocion) {
            this.promocion = promocion;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="insertarPromocionResponse", WrapperNamespace="http://services.CrewmanSystem.pucp.edu.pe/", IsWrapped=true)]
    public partial class insertarPromocionResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://services.CrewmanSystem.pucp.edu.pe/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int @return;
        
        public insertarPromocionResponse() {
        }
        
        public insertarPromocionResponse(int @return) {
            this.@return = @return;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface PromocionWSChannel : CrewmanSystem.PromocionWS.PromocionWS, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PromocionWSClient : System.ServiceModel.ClientBase<CrewmanSystem.PromocionWS.PromocionWS>, CrewmanSystem.PromocionWS.PromocionWS {
        
        public PromocionWSClient() {
        }
        
        public PromocionWSClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public PromocionWSClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PromocionWSClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PromocionWSClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        CrewmanSystem.PromocionWS.listarPromocionsResponse CrewmanSystem.PromocionWS.PromocionWS.listarPromocions(CrewmanSystem.PromocionWS.listarPromocionsRequest request) {
            return base.Channel.listarPromocions(request);
        }
        
        public CrewmanSystem.PromocionWS.promocion[] listarPromocions(string nombre, System.DateTime fechaIni, System.DateTime fechaFin) {
            CrewmanSystem.PromocionWS.listarPromocionsRequest inValue = new CrewmanSystem.PromocionWS.listarPromocionsRequest();
            inValue.nombre = nombre;
            inValue.fechaIni = fechaIni;
            inValue.fechaFin = fechaFin;
            CrewmanSystem.PromocionWS.listarPromocionsResponse retVal = ((CrewmanSystem.PromocionWS.PromocionWS)(this)).listarPromocions(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<CrewmanSystem.PromocionWS.listarPromocionsResponse> CrewmanSystem.PromocionWS.PromocionWS.listarPromocionsAsync(CrewmanSystem.PromocionWS.listarPromocionsRequest request) {
            return base.Channel.listarPromocionsAsync(request);
        }
        
        public System.Threading.Tasks.Task<CrewmanSystem.PromocionWS.listarPromocionsResponse> listarPromocionsAsync(string nombre, System.DateTime fechaIni, System.DateTime fechaFin) {
            CrewmanSystem.PromocionWS.listarPromocionsRequest inValue = new CrewmanSystem.PromocionWS.listarPromocionsRequest();
            inValue.nombre = nombre;
            inValue.fechaIni = fechaIni;
            inValue.fechaFin = fechaFin;
            return ((CrewmanSystem.PromocionWS.PromocionWS)(this)).listarPromocionsAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        CrewmanSystem.PromocionWS.actualizarPromocionResponse CrewmanSystem.PromocionWS.PromocionWS.actualizarPromocion(CrewmanSystem.PromocionWS.actualizarPromocionRequest request) {
            return base.Channel.actualizarPromocion(request);
        }
        
        public int actualizarPromocion(CrewmanSystem.PromocionWS.promocion promocion) {
            CrewmanSystem.PromocionWS.actualizarPromocionRequest inValue = new CrewmanSystem.PromocionWS.actualizarPromocionRequest();
            inValue.promocion = promocion;
            CrewmanSystem.PromocionWS.actualizarPromocionResponse retVal = ((CrewmanSystem.PromocionWS.PromocionWS)(this)).actualizarPromocion(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<CrewmanSystem.PromocionWS.actualizarPromocionResponse> CrewmanSystem.PromocionWS.PromocionWS.actualizarPromocionAsync(CrewmanSystem.PromocionWS.actualizarPromocionRequest request) {
            return base.Channel.actualizarPromocionAsync(request);
        }
        
        public System.Threading.Tasks.Task<CrewmanSystem.PromocionWS.actualizarPromocionResponse> actualizarPromocionAsync(CrewmanSystem.PromocionWS.promocion promocion) {
            CrewmanSystem.PromocionWS.actualizarPromocionRequest inValue = new CrewmanSystem.PromocionWS.actualizarPromocionRequest();
            inValue.promocion = promocion;
            return ((CrewmanSystem.PromocionWS.PromocionWS)(this)).actualizarPromocionAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        CrewmanSystem.PromocionWS.eliminarPromocionResponse CrewmanSystem.PromocionWS.PromocionWS.eliminarPromocion(CrewmanSystem.PromocionWS.eliminarPromocionRequest request) {
            return base.Channel.eliminarPromocion(request);
        }
        
        public int eliminarPromocion(int idPromocion) {
            CrewmanSystem.PromocionWS.eliminarPromocionRequest inValue = new CrewmanSystem.PromocionWS.eliminarPromocionRequest();
            inValue.idPromocion = idPromocion;
            CrewmanSystem.PromocionWS.eliminarPromocionResponse retVal = ((CrewmanSystem.PromocionWS.PromocionWS)(this)).eliminarPromocion(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<CrewmanSystem.PromocionWS.eliminarPromocionResponse> CrewmanSystem.PromocionWS.PromocionWS.eliminarPromocionAsync(CrewmanSystem.PromocionWS.eliminarPromocionRequest request) {
            return base.Channel.eliminarPromocionAsync(request);
        }
        
        public System.Threading.Tasks.Task<CrewmanSystem.PromocionWS.eliminarPromocionResponse> eliminarPromocionAsync(int idPromocion) {
            CrewmanSystem.PromocionWS.eliminarPromocionRequest inValue = new CrewmanSystem.PromocionWS.eliminarPromocionRequest();
            inValue.idPromocion = idPromocion;
            return ((CrewmanSystem.PromocionWS.PromocionWS)(this)).eliminarPromocionAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        CrewmanSystem.PromocionWS.insertarPromocionResponse CrewmanSystem.PromocionWS.PromocionWS.insertarPromocion(CrewmanSystem.PromocionWS.insertarPromocionRequest request) {
            return base.Channel.insertarPromocion(request);
        }
        
        public int insertarPromocion(CrewmanSystem.PromocionWS.promocion promocion) {
            CrewmanSystem.PromocionWS.insertarPromocionRequest inValue = new CrewmanSystem.PromocionWS.insertarPromocionRequest();
            inValue.promocion = promocion;
            CrewmanSystem.PromocionWS.insertarPromocionResponse retVal = ((CrewmanSystem.PromocionWS.PromocionWS)(this)).insertarPromocion(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<CrewmanSystem.PromocionWS.insertarPromocionResponse> CrewmanSystem.PromocionWS.PromocionWS.insertarPromocionAsync(CrewmanSystem.PromocionWS.insertarPromocionRequest request) {
            return base.Channel.insertarPromocionAsync(request);
        }
        
        public System.Threading.Tasks.Task<CrewmanSystem.PromocionWS.insertarPromocionResponse> insertarPromocionAsync(CrewmanSystem.PromocionWS.promocion promocion) {
            CrewmanSystem.PromocionWS.insertarPromocionRequest inValue = new CrewmanSystem.PromocionWS.insertarPromocionRequest();
            inValue.promocion = promocion;
            return ((CrewmanSystem.PromocionWS.PromocionWS)(this)).insertarPromocionAsync(inValue);
        }
    }
}