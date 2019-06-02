using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using PublicTransportApi.Core;
using PublicTransportApi.Core.Entities;
using PublicTransportApi.Services.Contracts.Base;
using PublicTransportApi.Services.Contracts.Failures;
using PublicTransportApi.Services.Contracts.Failures.Models;
using PublicTransportApi.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PublicTransportApi.Services
{
    class FailureService : BaseService, IFailureService
    {
        public FailureService(DefaultDbContext dbContext, ILogger logger, IHttpContextAccessor httpContextAccessor) : base(dbContext, logger, httpContextAccessor)
        {
        }

        public GetFailuresResponse GetFailures()
        {
            return ExecuteAction<GetFailuresResponse>(r => { r.Failures = _dbContext.Failures.Select(f => new FailureModel(f)).ToList(); });
        }

        public GetFailureResponse GetFailure(int FailureId)
        {
            return ExecuteAction<GetFailureResponse>((r) =>
            {
                r.Failure = new FailureModel(_dbContext.Failures.FirstOrDefault(u => u.Id == FailureId));
            });
        }

        public CreateFailureResponse CreateFailure(FailureModel failureModel)
        {
            return ExecuteAction<CreateFailureResponse>(r =>
            {
                var Failure = new Failure()
                {
                    Id = failureModel.Id,
                    VehicleId = failureModel.VehicleId,
                    NotifyingUserId = failureModel.NotifyingUserId,
                    Description = failureModel.Description,
                    Repaired = failureModel.Repaired,
                    NotificationDate = failureModel.NotificationDate,
                    AcceptedForRepair = failureModel.AcceptedForRepair,
                    PlannedEndOfRepairDate = failureModel.PlannedEndOfRepairDate,
                    EndOfRepairDate = failureModel.EndOfRepairDate
                };
                _dbContext.Failures.Add(Failure);
                _dbContext.SaveChanges();
                r.Id = Failure.Id;
            });
        }


        public BaseContractResponse UpdateFailure(FailureModel failureModel)
        {
            return ExecuteAction<BaseContractResponse>(r =>
            {
                var failure = _dbContext.Failures.FirstOrDefault(u => u.Id == failureModel.Id);
                failure.VehicleId = failureModel.VehicleId;
                failure.NotifyingUserId = failureModel.NotifyingUserId;
                failure.Description = failureModel.Description;
                failure.Repaired = failureModel.Repaired;
                failure.NotificationDate = failureModel.NotificationDate;
                failure.AcceptedForRepair = failureModel.AcceptedForRepair;
                failure.PlannedEndOfRepairDate = failureModel.PlannedEndOfRepairDate;
                failure.EndOfRepairDate = failureModel.EndOfRepairDate;
                _dbContext.Failures.Update(failure);
                _dbContext.SaveChanges();
            });
        }

        public BaseContractResponse DeleteFailure(int failureId)
        {
            return ExecuteAction<BaseContractResponse>(r =>
            {
                var failure = _dbContext.Failures.FirstOrDefault(v => v.Id == failureId);

                _dbContext.Failures.Remove(failure);
                _dbContext.SaveChanges();
            });

        }

    }
}
