package com.cloudthat.addressbookv2.mappers;

import com.cloudthat.addressbookv2.dtos.UserModel;
import com.cloudthat.addressbookv2.entities.User;
import org.mapstruct.Mapper;

@Mapper(componentModel = "spring")
public interface UserMapper {

    User toUser(UserModel userModel);
    UserModel toUserModel(User user);
}
