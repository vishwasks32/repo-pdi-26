package com.cloudthat.addressbookv2.mappers;

import com.cloudthat.addressbookv2.dtos.TagModel;
import com.cloudthat.addressbookv2.models.Tag;

public interface TagMapper {
    Tag toTag(TagModel tagModel);
    TagModel toTagModel(Tag tag);
}
