using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using SignatureDomain.Entities;
using static SignatureCommon.Enums;

namespace SignatureApplication.Files.ViewModels
{
    // public class CreateFileViewModel : IRequest
    // {
    //     public string FileName { get; set; }
    //     public string Path { get; set; }
    //     public int Size { get; set; }
    //     public string Type { get; set; }
    //     public string Comentary { get; set; }
    //     public FileStatus Status { get; set; }
    //     public int SignedBy { get; set; }
    //     
    //     
    // }

    public class CreateFileViewModel : IRequest
    {
        public IFormFile File { get; set; }
        public Guid UserId { get; set; }
        public List<User> AssignedUsers { get; set; }
    }
}
