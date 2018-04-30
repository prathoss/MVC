using System;
using Microsoft.EntityFrameworkCore;
using MVC.Models;
using MVC.Data;

namespace ASPNET2.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public bool TryDbModel()
        {
            return false;
        }
    }
}