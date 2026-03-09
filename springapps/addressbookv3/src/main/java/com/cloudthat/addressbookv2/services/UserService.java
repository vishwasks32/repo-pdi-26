package com.cloudthat.addressbookv2.services;

import com.cloudthat.addressbookv2.dtos.UserModel;
import com.cloudthat.addressbookv2.entities.User;
import com.cloudthat.addressbookv2.repositories.UserRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.dao.DataIntegrityViolationException;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.stereotype.Service;

@Service
public class UserService{

    @Autowired
    private UserRepository userRepository;


    @Autowired
    private BCryptPasswordEncoder passwordEncoder;

    public User registerUser(UserModel userModel) {
        // TODO Auto-generated method stub
        User user = new User();
        user.setRole(userModel.getRole());
        user.setPassword(passwordEncoder.encode(userModel.getPassword()));

        try {
            userRepository.save(user);
            return user;
        } catch (DataIntegrityViolationException e) {
            // TODO: handle exception
            throw new DataIntegrityViolationException(null);
        }

    }


    public Boolean existsByEmail(String email) {
        // TODO Auto-generated method stub
        return userRepository.existsByEmailId(email);
    }


}