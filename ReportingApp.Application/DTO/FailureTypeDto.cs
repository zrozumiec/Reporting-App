﻿using System.ComponentModel;
using ReportingApp.Application.DTO.Base;

namespace ReportingApp.Application.DTO
{
    /// <summary>
    /// Class represents failure type.
    /// </summary>
    public class FailureTypeDto : BaseDto
    {
        /// <summary>
        /// Gets or sets failure type description.
        /// </summary>
        [DisplayName("Failure type description")]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets failure category id.
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Gets or sets failure category.
        /// </summary>
        public FailureCategoryDto Category { get; set; } = new FailureCategoryDto();

        /// <summary>
        /// Gets or sets failure of specified type.
        /// </summary>
        public ICollection<FailureDto> Failures { get; set; } = new List<FailureDto>();
    }
}
