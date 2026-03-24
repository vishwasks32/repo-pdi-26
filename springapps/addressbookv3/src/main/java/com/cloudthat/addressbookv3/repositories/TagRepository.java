package com.cloudthat.addressbookv3.repositories;

import com.cloudthat.addressbookv3.entities.Tag;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import java.util.Optional;

@Repository
public interface TagRepository extends JpaRepository<Tag, Long> {
    public Optional<Tag> findByTagName(String tagName);
}
