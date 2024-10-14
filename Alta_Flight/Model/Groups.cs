﻿using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alta_Flight.Model
{
    public class Groups
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Tự sinh ID

        public int group_id { get; set; }

        public string Group_Name { get; set; }

        public string Member { get; set; }

        public DateTime CreateDate { get; set; }

        public string note { get; set; }

        // Thuộc tính điều hướng đến bảng trung gian (nhiều-nhiều)
        //public ICollection<Account_Groups> AccountGroups { get; set; }

    }
}
