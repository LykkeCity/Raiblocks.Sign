using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Lykke.Service.RaiblocksSign.Core.Domain;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Newtonsoft.Json;

namespace Lykke.Service.RaiblocksSign.Models
{
    [DataContract]
    public class SignRequest : IValidatableObject
    {
        [DataMember]
        [Required]
        public string[] PrivateKeys { get; set; }

        [DataMember]
        [Required]
        public string TransactionContext { get; set; }

        [ValidateNever]
        public RaiBlock Block { get; private set; }

        [ValidateNever]
        public string Key { get; private set; }

        [OnDeserialized]
        public void Init(StreamingContext streamingContext = default)
        {
            // leave properties null if deserialization fails, 
            // see Validate for actual validation

            if (Block == null)
            {
                try
                {
                    Block = JsonConvert.DeserializeObject<RaiBlock>(TransactionContext);
                }
                catch(Exception e)
                {
                    Block = null;
                }
            }

            if (Key == null)
            {
                try
                {
                    Key = PrivateKeys.Single();
                }
                catch
                {
                    Key = null;
                }
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var result = new List<ValidationResult>();

            Init();

            //TODO: Add another validation rules for Block.
            if (string.IsNullOrWhiteSpace(Block.type))
            {
                result.Add(new ValidationResult("Invalid block data", new[] { nameof(TransactionContext) }));
            }

            if (string.IsNullOrWhiteSpace(Key))
            {
                result.Add(new ValidationResult("Invalid key", new[] { nameof(PrivateKeys) }));
            }

            return result;
        }
    }
}
