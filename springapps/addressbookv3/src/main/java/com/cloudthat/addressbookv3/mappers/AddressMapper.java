package com.cloudthat.addressbookv3.mappers;

import com.cloudthat.addressbookv3.dtos.AddressModel;
import com.cloudthat.addressbookv3.entities.Address;
import org.mapstruct.Mapper;

@Mapper(componentModel = "spring")
public interface AddressMapper {

    Address toAddress(AddressModel addressModel);
    AddressModel toAddressModel(Address address);
}
