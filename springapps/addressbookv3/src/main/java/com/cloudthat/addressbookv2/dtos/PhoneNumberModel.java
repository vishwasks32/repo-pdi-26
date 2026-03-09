package com.cloudthat.addressbookv2.dtos;

import com.cloudthat.addressbookv2.entities.PhoneType;
import jakarta.validation.constraints.NotBlank;
import jakarta.validation.constraints.Pattern;

public record PhoneNumberModel(
        @NotBlank(message = "Country Code is required")
        @Pattern(regexp = "^\\+[1-9]\\d{0,3}$", message = "Invalid Country code format")
        String countryCode,
        Integer number,
        PhoneType phoneType
) {
}
