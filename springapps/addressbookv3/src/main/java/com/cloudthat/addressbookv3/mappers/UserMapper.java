package com.cloudthat.addressbookv3.mappers;

import com.cloudthat.addressbookv3.dtos.UserModel;
import com.cloudthat.addressbookv3.entities.User;
import org.mapstruct.Mapper;

@Mapper(componentModel = "spring")
public interface UserMapper {

    User toUser(UserModel userModel);
    UserModel toUserModel(User user);
}
