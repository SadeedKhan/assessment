using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NowAssessment.Domain.Entities.Base
{
    public class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }

        public DateTime ModifiedDate { get; private set; }
        public Guid ModifiedBy { get; private set; }

        public BaseEntity()
        {
            ModifiedDate = DateTime.Now;
        }
    }
}
