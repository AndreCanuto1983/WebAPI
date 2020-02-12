using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    /// <summary>
    /// Esta classe tem o objetivo de inserir os campos padrões para saber a hora de criação etc
    /// </summary>
    public abstract class ModelBase
    {
        #region [ Contructor ]

        /// <summary>
        /// No construtor as propriedades <see cref="CreationDate"/> e <see cref="UpdateDate"/> são inicializadas,
        /// a propriedade <see cref="CreationDate"/> recebe como valor o horário atual do sistema atraves do <see cref="DateTime.Now"/>
        /// e a propriedade <see cref="UpdateDate"/> recebe o valor da <see cref="CreationDate"/>
        /// </summary>
        public ModelBase()
        {
            CreationDate = DateTime.Now;
            UpdateDate = CreationDate;
        }

        #endregion

        #region [ Properties ]

        /// <summary>
        /// Seta ou retorna a data e hora da criação do registro no banco de dados.
        /// Caso a propriedade <see cref="AutoDate"/> estiver como 'true' essa propriedade utilizara a data
        /// corrente no momento da criação.
        /// 
        /// Se o programador utilizar o Context diretamente para efetuar operações dentro do banco de dados, o programador devera
        /// setar manualmente essa propriedade.
        /// </summary>
        [Required]
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Seta ou retorna a data e hora da ultima alteração do registro no banco de dados.
        /// Caso a propriedade <see cref="AutoDate"/> estiver como 'true':
        /// Inserção do registro: utiliza a mesma data e hora da <see cref="CreationDate"/>
        /// Atualização do registro: utiliza a data corrente do sistema.
        /// 
        /// Se o programador utilizar o Context diretamente para efetuar operações dentro do banco de dados, o programador devera
        /// setar manualmente essa propriedade.
        /// </summary>
        [Required]
        public DateTime UpdateDate { get; set; }

        /// <summary>
        /// Seta ou retorna se o registro esta "removido" do banco de dados.
        /// </summary>
        [Required]
        public bool IsDeleted { get; set; }

        #endregion                
    }
}