package com.cloudthat.addressbookv2.dtos;

import com.cloudthat.addressbookv2.models.Gender;
import jakarta.validation.constraints.Email;
import jakarta.validation.constraints.NotBlank;
import jakarta.validation.constraints.Size;

import java.time.LocalDate;
import java.util.List;

public record ContactModel(
        Long id,

        @NotBlank(message = "Contact name is required")
        @Size(min = 3, max = 20, message = "Contact Name must be between 3 and 20 characters")
        String contactName,

        @NotBlank(message = "Contact email Id is required")
        @Email(message = "Invalid email format")
        String emailId,

        Gender gender,
        byte[] profilePicture,
        LocalDate dob,
        AddressModel address,
        List<PhoneNumberModel> phoneNumbers,
        List<TagModel> tags
) {
}
