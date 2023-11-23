﻿using System.Collections.Generic;

namespace AvSBookStore.Web.Models
{
    public class ConfirmationModel
    {
        public int OrderId { get; set; }

        public string CellPhone { get; set; }

        public Dictionary<string, string> Errors { get; set; } = new Dictionary<string, string>();
    }
}
