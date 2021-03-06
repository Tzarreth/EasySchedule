﻿using System.Collections.Generic;
using System.ServiceModel;
using Core;

namespace ServiceLibrary.TemplateSchedules
{
    [ServiceContract]
    public interface ITemplateScheduleService
    {
        [OperationContract]
        List<TemplateSchedule> GetAllTemplateSchedules();

        [OperationContract]
        void AddTemplateScheduleToDb(TemplateSchedule templateSchedule);

        [OperationContract]
        void UpdateTemplateSchedule(TemplateSchedule templateSchedule);

        [OperationContract]
        void UpdateTemplateScheduleWithDelete(TemplateSchedule templateSchedule, List<TemplateShift> deletedTemplateShifts);
    }
}
