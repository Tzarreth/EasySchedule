﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DesktopClient.TemplateScheduleService {
    using System.Runtime.Serialization;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DayOfWeek", Namespace="http://schemas.datacontract.org/2004/07/System")]
    public enum DayOfWeek : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Sunday = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Monday = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Tuesday = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Wednesday = 3,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Thursday = 4,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Friday = 5,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Saturday = 6,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="TemplateScheduleService.ITemplateScheduleService")]
    public interface ITemplateScheduleService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITemplateScheduleService/GetAllTemplateSchedules", ReplyAction="http://tempuri.org/ITemplateScheduleService/GetAllTemplateSchedulesResponse")]
        System.Collections.Generic.List<Core.TemplateSchedule> GetAllTemplateSchedules();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITemplateScheduleService/GetAllTemplateSchedules", ReplyAction="http://tempuri.org/ITemplateScheduleService/GetAllTemplateSchedulesResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<Core.TemplateSchedule>> GetAllTemplateSchedulesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITemplateScheduleService/AddTemplateScheduleToDb", ReplyAction="http://tempuri.org/ITemplateScheduleService/AddTemplateScheduleToDbResponse")]
        void AddTemplateScheduleToDb(Core.TemplateSchedule templateSchedule);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITemplateScheduleService/AddTemplateScheduleToDb", ReplyAction="http://tempuri.org/ITemplateScheduleService/AddTemplateScheduleToDbResponse")]
        System.Threading.Tasks.Task AddTemplateScheduleToDbAsync(Core.TemplateSchedule templateSchedule);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITemplateScheduleService/UpdateTemplateSchedule", ReplyAction="http://tempuri.org/ITemplateScheduleService/UpdateTemplateScheduleResponse")]
        void UpdateTemplateSchedule(Core.TemplateSchedule templateSchedule);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITemplateScheduleService/UpdateTemplateSchedule", ReplyAction="http://tempuri.org/ITemplateScheduleService/UpdateTemplateScheduleResponse")]
        System.Threading.Tasks.Task UpdateTemplateScheduleAsync(Core.TemplateSchedule templateSchedule);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITemplateScheduleService/UpdateTemplateScheduleWithDelete", ReplyAction="http://tempuri.org/ITemplateScheduleService/UpdateTemplateScheduleWithDeleteRespo" +
            "nse")]
        void UpdateTemplateScheduleWithDelete(Core.TemplateSchedule templateSchedule, System.Collections.Generic.List<Core.TemplateShift> deletedTemplateShifts);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITemplateScheduleService/UpdateTemplateScheduleWithDelete", ReplyAction="http://tempuri.org/ITemplateScheduleService/UpdateTemplateScheduleWithDeleteRespo" +
            "nse")]
        System.Threading.Tasks.Task UpdateTemplateScheduleWithDeleteAsync(Core.TemplateSchedule templateSchedule, System.Collections.Generic.List<Core.TemplateShift> deletedTemplateShifts);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ITemplateScheduleServiceChannel : DesktopClient.TemplateScheduleService.ITemplateScheduleService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TemplateScheduleServiceClient : System.ServiceModel.ClientBase<DesktopClient.TemplateScheduleService.ITemplateScheduleService>, DesktopClient.TemplateScheduleService.ITemplateScheduleService {
        
        public TemplateScheduleServiceClient() {
        }
        
        public TemplateScheduleServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TemplateScheduleServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TemplateScheduleServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TemplateScheduleServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Collections.Generic.List<Core.TemplateSchedule> GetAllTemplateSchedules() {
            return base.Channel.GetAllTemplateSchedules();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<Core.TemplateSchedule>> GetAllTemplateSchedulesAsync() {
            return base.Channel.GetAllTemplateSchedulesAsync();
        }
        
        public void AddTemplateScheduleToDb(Core.TemplateSchedule templateSchedule) {
            base.Channel.AddTemplateScheduleToDb(templateSchedule);
        }
        
        public System.Threading.Tasks.Task AddTemplateScheduleToDbAsync(Core.TemplateSchedule templateSchedule) {
            return base.Channel.AddTemplateScheduleToDbAsync(templateSchedule);
        }
        
        public void UpdateTemplateSchedule(Core.TemplateSchedule templateSchedule) {
            base.Channel.UpdateTemplateSchedule(templateSchedule);
        }
        
        public System.Threading.Tasks.Task UpdateTemplateScheduleAsync(Core.TemplateSchedule templateSchedule) {
            return base.Channel.UpdateTemplateScheduleAsync(templateSchedule);
        }
        
        public void UpdateTemplateScheduleWithDelete(Core.TemplateSchedule templateSchedule, System.Collections.Generic.List<Core.TemplateShift> deletedTemplateShifts) {
            base.Channel.UpdateTemplateScheduleWithDelete(templateSchedule, deletedTemplateShifts);
        }
        
        public System.Threading.Tasks.Task UpdateTemplateScheduleWithDeleteAsync(Core.TemplateSchedule templateSchedule, System.Collections.Generic.List<Core.TemplateShift> deletedTemplateShifts) {
            return base.Channel.UpdateTemplateScheduleWithDeleteAsync(templateSchedule, deletedTemplateShifts);
        }
    }
}
