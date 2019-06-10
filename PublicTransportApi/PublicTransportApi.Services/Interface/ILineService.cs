using PublicTransportApi.Services.Contracts.Base;
using PublicTransportApi.Services.Contracts.Lines;
using PublicTransportApi.Services.Contracts.Lines.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicTransportApi.Services.Interface
{
    public interface ILineService
    {
        GetLinesResponse GetLines();
        GetLineResponse GetLine(int LineId);
        CreateLineResponse CreateLine(LineModel lineModel);
        BaseContractResponse UpdateLine(LineModel lineModel);
        BaseContractResponse DeleteLine(int lineId);

    }
}
