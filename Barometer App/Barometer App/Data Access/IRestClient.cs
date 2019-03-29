using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RESTClient.DTOs;

namespace RESTClient
{
    public interface IRestClient
    {
        //List<BarSimpleDto> GetBestBarsList(); WAT IS DIS
        bool CreateBar(BarSimpleDto newBar);
        bool EditBar(BarSimpleDto editedBar);
        List<BarSimpleDto> GetBarList();
        BarSimpleDto GetDetailedBar(string id);
    }
}
