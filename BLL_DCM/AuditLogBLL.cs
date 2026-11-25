using System.Collections.Generic;
using DAL_DCM;
using DTO_DCM;

namespace BLL_DCM
{
    public class AuditLogBLL
    {
        private readonly AuditLogDAL _dal = new();

        public void Log(int? accountId, string actionType, string entityName, int entityId, string description)
        {
            _dal.InsertLog(accountId, actionType, entityName, entityId, description);
        }

        public List<AuditLogDTO> GetAllLogs() => _dal.GetAllLogs();
    }
}
