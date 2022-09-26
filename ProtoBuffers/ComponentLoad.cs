using System.ComponentModel.DataAnnotations;

namespace ProtoBuffers
{
    public class ComponentLoad 

    {
        [Required]
        [StringLength(150)]
        public string Code { get; set; } = default!;
        [Required]
        public bool Fetch { get; set; } = default!;
        [Required]
        [StringLength(150)]
        public string Path { get; set; } = default!;
    }
}
