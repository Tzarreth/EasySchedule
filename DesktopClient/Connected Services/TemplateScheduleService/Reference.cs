﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using Core;

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
        List<TemplateSchedule> GetAllTemplateSchedules();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITemplateScheduleService/GetAllTemplateSchedules", ReplyAction="http://tempuri.org/ITemplateScheduleService/GetAllTemplateSchedulesResponse")]
        Task<List<TemplateSchedule>> GetAllTemplateSchedulesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITemplateScheduleService/FindTemplateScheduleByName", ReplyAction="http://tempuri.org/ITemplateScheduleService/FindTemplateScheduleByNameResponse")]
        Core.TemplateSchedule FindTemplateScheduleByName(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITemplateScheduleService/FindTemplateScheduleByName", ReplyAction="http://tempuri.org/ITemplateScheduleService/FindTemplateScheduleByNameResponse")]
        System.Threading.Tasks.Task<Core.TemplateSchedule> FindTemplateScheduleByNameAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITemplateScheduleService/AddTemplateScheduleToDb", ReplyAction="http://tempuri.org/ITemplateScheduleService/AddTemplateScheduleToDbResponse")]
        void AddTemplateScheduleToDb(Core.TemplateSchedule templateSchedule);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITemplateScheduleService/AddTemplateScheduleToDb", ReplyAction="http://tempuri.org/ITemplateScheduleService/AddTemplateScheduleToDbResponse")]
        System.Threading.Tasks.Task AddTemplateScheduleToDbAsync(Core.TemplateSchedule templateSchedule);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITemplateScheduleService/AddTemplateShift", ReplyAction="http://tempuri.org/ITemplateScheduleService/AddTemplateShiftResponse")]
        void AddTemplateShift(Core.TemplateShift templateShift);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITemplateScheduleService/AddTemplateShift", ReplyAction="http://tempuri.org/ITemplateScheduleService/AddTemplateShiftResponse")]
        System.Threading.Tasks.Task AddTemplateShiftAsync(Core.TemplateShift templateShift);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITemplateScheduleService/UpdateTemplateSchedule", ReplyAction="http://tempuri.org/ITemplateScheduleService/UpdateTemplateScheduleResponse")]
        void UpdateTemplateSchedule(Core.TemplateSchedule templateSchedule);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITemplateScheduleService/UpdateTemplateSchedule", ReplyAction="http://tempuri.org/ITemplateScheduleService/UpdateTemplateScheduleResponse")]
        System.Threading.Tasks.Task UpdateTemplateScheduleAsync(Core.TemplateSchedule templateSchedule);
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
        
        public List<TemplateSchedule> GetAllTemplateSchedules() {
            return base.Channel.GetAllTemplateSchedules();
        }
        
        public Task<List<TemplateSchedule>> GetAllTemplateSchedulesAsync() {
            return base.Channel.GetAllTemplateSchedulesAsync();
        }
        
        public Core.TemplateSchedule FindTemplateScheduleByName(string name) {
            return base.Channel.FindTemplateScheduleByName(name);
        }
        
        public System.Threading.Tasks.Task<Core.TemplateSchedule> FindTemplateScheduleByNameAsync(string name) {
            return base.Channel.FindTemplateScheduleByNameAsync(name);
        }
        
        public void AddTemplateScheduleToDb(Core.TemplateSchedule templateSchedule) {
            base.Channel.AddTemplateScheduleToDb(templateSchedule);
        }
        
        public System.Threading.Tasks.Task AddTemplateScheduleToDbAsync(Core.TemplateSchedule templateSchedule) {
            return base.Channel.AddTemplateScheduleToDbAsync(templateSchedule);
        }
        
        public void AddTemplateShift(Core.TemplateShift templateShift) {
            base.Channel.AddTemplateShift(templateShift);
        }
        
        public System.Threading.Tasks.Task AddTemplateShiftAsync(Core.TemplateShift templateShift) {
            return base.Channel.AddTemplateShiftAsync(templateShift);
        }
        
        public void UpdateTemplateSchedule(Core.TemplateSchedule templateSchedule) {
            base.Channel.UpdateTemplateSchedule(templateSchedule);
        }
        
        public System.Threading.Tasks.Task UpdateTemplateScheduleAsync(Core.TemplateSchedule templateSchedule) {
            return base.Channel.UpdateTemplateScheduleAsync(templateSchedule);
        }
    }
}