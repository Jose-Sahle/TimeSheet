using SHL.IRetorno.Model;
using SHL.Syncronism.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SHL.Syncronism.BusinessLayer;
using SHL.TimeSheet.BusinessLayer;
using SHL.TimeSheet.Model;
using SHL.Project.BusinessLayer;
using SHL.Project.Model;
using SHL.Task.BusinessLayer;
using SHL.Task.Model;

namespace SHL.Syncronism
{
    /// <summary>
    /// 
    /// </summary>
    public static class TreatFunctions
    {
        #region [Public Methods]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Group"></param>
        /// <param name="entity"></param>
        /// <param name="transaction"></param>
        /// <param name="retornos"></param>
        public static void TreatTimeSheet(String Group, SYNCRONISM entity, ref SqlTransaction transaction, ref List<RETORNO> retornos)
        {
            TIMESHEET_BL timesheetbl = new TIMESHEET_BL();
            TIMESHEET timesheet = JsonConvert.DeserializeObject<TIMESHEET>(entity.DATA);
            TIMESHEET timesheetconsulta = new TIMESHEET();


            switch (entity.OPERATION)
            {
                case 1:                     // Inclusão
                    timesheetbl.Insert(Group, timesheet, transaction, ref retornos);
                    break;
                case 2:                     // Atulização
                    timesheetconsulta.DATE_RG = timesheet.DATE_RG;
                    timesheetconsulta = timesheetbl.Select(Group, timesheetconsulta);
                    timesheet.ID_TIMESHEET = timesheetconsulta.ID_TIMESHEET;

                    timesheetbl.Update(Group, timesheet, transaction, ref retornos);
                    break;
                case 3:                     // Exclusão
                    timesheetconsulta.DATE_RG = timesheet.DATE_RG;
                    timesheetconsulta = timesheetbl.Select(Group, timesheetconsulta);
                    timesheet.ID_TIMESHEET = timesheetconsulta.ID_TIMESHEET;

                    timesheetbl.Delete(Group, timesheet, transaction);
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Group"></param>
        /// <param name="entity"></param>
        /// <param name="transaction"></param>
        /// <param name="retornos"></param>
        public static void TreatParameter(String Group, SYNCRONISM entity, ref SqlTransaction transaction, ref List<RETORNO> retornos)
        {
            PARAMETER_BL parameterbl = new PARAMETER_BL();
            PARAMETER parameter = JsonConvert.DeserializeObject<PARAMETER>(entity.DATA);

            switch (entity.OPERATION)
            {
                case 1:                     // Inclusão
                    parameterbl.Insert(Group, parameter, transaction, ref retornos);
                    break;
                case 2:                     // Atulização
                    parameterbl.Update(Group, parameter, transaction, ref retornos);
                    break;
                case 3:                     // Exclusão
                    parameterbl.Delete(Group, parameter, transaction);
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Group"></param>
        /// <param name="entity"></param>
        /// <param name="transaction"></param>
        /// <param name="retornos"></param>
        public static void TreatProject(String Group, SYNCRONISM entity, ref SqlTransaction transaction, ref List<RETORNO> retornos)
        {
            PROJECT_BL projectbl = new PROJECT_BL();
            PROJECT project = JsonConvert.DeserializeObject<PROJECT>(entity.DATA);
            PROJECT projectconsulta = new PROJECT();

            switch (entity.OPERATION)
            {
                case 1:                     // Inclusão
                    projectbl.Insert(Group, project, transaction, ref retornos);
                    break;
                case 2:                     // Atulização
                    projectconsulta.NAME = project.NAME;
                    projectconsulta = projectbl.Select(Group, projectconsulta);
                    project.ID_PROJECT = projectconsulta.ID_PROJECT;

                    projectbl.Update(Group, project, transaction, ref retornos);
                    break;
                case 3:                     // Exclusão
                    projectconsulta.NAME = project.NAME;
                    projectconsulta = projectbl.Select(Group, projectconsulta);
                    project.ID_PROJECT = projectconsulta.ID_PROJECT;

                    projectbl.Delete(Group, project, transaction);
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Group"></param>
        /// <param name="entity"></param>
        /// <param name="transaction"></param>
        /// <param name="retornos"></param>
        public static void TreatTask(String Group, SYNCRONISM entity, ref SqlTransaction transaction, ref List<RETORNO> retornos)
        {
            throw new Exception("Necessário ajustar esse tratamento com ID do servidor");
            /*
            TASK_BL taskbl = new TASK_BL();
            TASK task = JsonConvert.DeserializeObject<TASK>(entity.DATA);
            TASK taskconsulta = new TASK();

            switch (entity.OPERATION)
            {
                case 1:                     // Inclusão
                    taskbl.Insert(Group, task, transaction, ref retornos);
                    break;
                case 2:                     // Atulização
                    taskbl.Update(Group, task, transaction, ref retornos);
                    break;
                case 3:                     // Exclusão
                    taskbl.Delete(Group, task, transaction);
                    break;
            }*/
        }
        #endregion
    }
}
