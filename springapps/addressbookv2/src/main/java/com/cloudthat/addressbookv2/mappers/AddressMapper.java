package com.cloudthat.addressbookv2.mappers;

import com.cloudthat.addressbookv2.dtos.AddressModel;
import com.cloudthat.addressbookv2.models.Address;
import org.mapstruct.Mapper;
import org.springframework.stereotype.Component;

@Mapper(componentModel = "spring")
public interface AddressMapper {

    Address toAddress(AddressModel addressModel);
    AddressModel toAddressModel(Address address);
}
