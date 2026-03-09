package com.cloudthat.addressbookv2.repositories;

import com.cloudthat.addressbookv2.entities.User;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface UserRepository extends JpaRepository<User, Long> {
    User findByEmailId(String email);
    Boolean existsByEmailId(String email);
}
