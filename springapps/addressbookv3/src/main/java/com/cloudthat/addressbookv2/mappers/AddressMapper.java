package com.cloudthat.addressbookv2.mappers;

import com.cloudthat.addressbookv2.dtos.AddressModel;
import com.cloudthat.addressbookv2.entities.Address;
import org.mapstruct.Mapper;

@Mapper(componentModel = "spring")
public interface AddressMapper {

    Address toAddress(AddressModel addressModel);
    AddressModel toAddressModel(Address address);
}
