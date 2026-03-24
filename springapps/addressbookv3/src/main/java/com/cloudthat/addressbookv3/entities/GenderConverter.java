package com.cloudthat.addressbookv3.entities;

import jakarta.persistence.AttributeConverter;
import jakarta.persistence.Converter;

@Converter
public class GenderConverter implements AttributeConverter<Gender, Character> {

    @Override
    public Character convertToDatabaseColumn(Gender gender) {
        if(gender == null){
            return  null;
        }

        return gender.getCode();
    }

    @Override
    public Gender convertToEntityAttribute(Character character) {
        if(character == null){
            return null;
        }

        return Gender.fromCode(character);

    }
}
