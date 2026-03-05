package com.cloudthat.addressbookv2.mappers;

import com.cloudthat.addressbookv2.dtos.TagModel;
import com.cloudthat.addressbookv2.models.Tag;
import org.mapstruct.Mapper;
import org.mapstruct.factory.Mappers;

@Mapper(componentModel = "spring")
public interface TagMapper {
    TagMapper INSTANCE = Mappers.getMapper(TagMapper.class);
    Tag toTag(TagModel tagModel);
    TagModel toTagModel(Tag tag);
}
