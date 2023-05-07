using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Data.Data.Repository.Models
{
    public class TableModel
    {
        public TableModel() { }

        public TableModel(int id, int code, bool status, DateTime? startAt)
        {
            Id = id;
            Code = code;
            Status = status;
            StartAt = startAt;
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "O código da mesa é obrigatório")]
        public int Code { get; set; }
        public bool Status { get; set; } = default!;
        public DateTime? StartAt { get; set; } = default!;

        public List<ServiceModel>? Services { get; set; }
    }
}
