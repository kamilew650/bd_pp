using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using PublicTransportApi.Core;
using PublicTransportApi.Core.Entities;
using PublicTransportApi.Services.Contracts.Base;
using PublicTransportApi.Services.Contracts.Lines;
using PublicTransportApi.Services.Contracts.Lines.Models;
using PublicTransportApi.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PublicTransportApi.Services
{
    class LineService : BaseService, ILineService
    {
        public LineService(DefaultDbContext dbContext, ILogger<LineService> logger, IHttpContextAccessor httpContextAccessor) : base(dbContext, logger, httpContextAccessor)
        {
        }

        public GetLinesResponse GetLines()
        {
            return ExecuteAction<GetLinesResponse>(r => { r.Lines = _dbContext.Lines.Select(f => new LineModel(f)).ToList(); });
        }

        public GetLineResponse GetLine(int LineId)
        {
            return ExecuteAction<GetLineResponse>((r) =>
            {
                r.Line = new LineModel(_dbContext.Lines.FirstOrDefault(u => u.Id == LineId));
            });
        }

        public CreateLineResponse CreateLine(LineModel lineModel)
        {
            return ExecuteAction<CreateLineResponse>(r =>
            {
                var line = new Line()
                {
                    Id = lineModel.Id,
                    Number = lineModel.Number
                };
                _dbContext.Lines.Add(line);
                _dbContext.SaveChanges();
                r.Id = line.Id;
            });
        }


        public BaseContractResponse UpdateLine(LineModel lineModel)
        {
            return ExecuteAction<BaseContractResponse>(r =>
            {
                var line = _dbContext.Lines.FirstOrDefault(u => u.Id == lineModel.Id);
                line.Id = lineModel.Id;
                line.Number = lineModel.Number;
                _dbContext.Lines.Update(line);
                _dbContext.SaveChanges();
            });
        }

        public BaseContractResponse DeleteLine(int lineId)
        {
            return ExecuteAction<BaseContractResponse>(r =>
            {
                var line = _dbContext.Lines.FirstOrDefault(v => v.Id == lineId);

                _dbContext.Lines.Remove(line);
                _dbContext.SaveChanges();
            });

        }


    }
}
