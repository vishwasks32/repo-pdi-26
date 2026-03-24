package com.cloudthat.addressbookv3.mappers;

import com.cloudthat.addressbookv3.dtos.TagModel;
import com.cloudthat.addressbookv3.entities.Tag;
import org.mapstruct.Mapper;
import org.mapstruct.factory.Mappers;

@Mapper(componentModel = "spring")
public interface TagMapper {
    TagMapper INSTANCE = Mappers.getMapper(TagMapper.class);
    Tag toTag(TagModel tagModel);
    TagModel toTagModel(Tag tag);
}
