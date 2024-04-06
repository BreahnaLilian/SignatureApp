﻿using SignatureDomain.Common;
using static SignatureDomain.Common.Enums;

namespace SignatureDomain.Entities
{
    public class File : AuditableEntity
    {
        public string FileName { get; set; }
        public string Path { get; set; }
        public int Size { get; set; }
        public string Type { get; set; }
        public string Commentary { get; set; }
        public FileStatus Stauts { get; set; }
        public int SignedBy { get; set; }

        public List<User> AssignetUsers { get; set; }
    }
}
