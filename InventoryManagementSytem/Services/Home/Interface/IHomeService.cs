using InventoryManagementSytem.Models;
using Microsoft.AspNetCore.SignalR;

namespace InventoryManagementSytem.Services.Home.Interface
{
    public interface IHomeService
    {
        Task<IndexViewModel> GetCount();
    }
}
