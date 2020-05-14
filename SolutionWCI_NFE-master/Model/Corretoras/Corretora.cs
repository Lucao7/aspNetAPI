using Model.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model.Corretoras
{
    [Table("CUS_Customer")]
    public class Corretora : BaseModel
    {
        [Key]
        public int CorretoraId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resource.Resource), ErrorMessageResourceName = "MSG_FIELD_NULL")]
        [StringLength(14, ErrorMessageResourceType = typeof(Resource.Resource), ErrorMessageResourceName = "MSG_NUMBER_OF_CHARACTERS_EXCEEDED", ErrorMessage = null)]
        public string CnpjCpf { get; set; }

        [StringLength(150, ErrorMessageResourceType = typeof(Resource.Resource), ErrorMessageResourceName = "MSG_NUMBER_OF_CHARACTERS_EXCEEDED", ErrorMessage = null)]
        public string RazaoSocialCorretor { get; set; }

        [StringLength(150, ErrorMessageResourceType = typeof(Resource.Resource), ErrorMessageResourceName = "MSG_NUMBER_OF_CHARACTERS_EXCEEDED", ErrorMessage = null)]
        public string EnderecoCorretor { get; set; }

        [StringLength(150, ErrorMessageResourceType = typeof(Resource.Resource), ErrorMessageResourceName = "MSG_NUMBER_OF_CHARACTERS_EXCEEDED", ErrorMessage = null)]
        public string Bairro { get; set; }

        [StringLength(150, ErrorMessageResourceType = typeof(Resource.Resource), ErrorMessageResourceName = "MSG_NUMBER_OF_CHARACTERS_EXCEEDED", ErrorMessage = null)]
        public string Complemento { get; set; }

        [StringLength(150, ErrorMessageResourceType = typeof(Resource.Resource), ErrorMessageResourceName = "MSG_NUMBER_OF_CHARACTERS_EXCEEDED", ErrorMessage = null)]
        public string Cidade { get; set; }

        [StringLength(2, ErrorMessageResourceType = typeof(Resource.Resource), ErrorMessageResourceName = "MSG_NUMBER_OF_CHARACTERS_EXCEEDED", ErrorMessage = null)]
        public string Estado { get; set; }

        [StringLength(150, ErrorMessageResourceType = typeof(Resource.Resource), ErrorMessageResourceName = "MSG_NUMBER_OF_CHARACTERS_EXCEEDED", ErrorMessage = null)]
        public string MeioComunicacao { get; set; }

        [StringLength(150, ErrorMessageResourceType = typeof(Resource.Resource), ErrorMessageResourceName = "MSG_NUMBER_OF_CHARACTERS_EXCEEDED", ErrorMessage = null)]
        public string TipoMeioComunicacao { get; set; }
    }
}
