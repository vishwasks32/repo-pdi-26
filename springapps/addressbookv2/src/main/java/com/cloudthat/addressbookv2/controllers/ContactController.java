package com.cloudthat.addressbookv2.controllers;

import com.cloudthat.addressbookv2.models.Contact;
import com.cloudthat.addressbookv2.services.ContactService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api/v1/contacts")
public class ContactController {

    @Autowired
    private ContactService contactService;

    @GetMapping
    public List<Contact> getAll(){
        return contactService.getAllContacts();
    }

    @PostMapping
    public Contact create(@RequestBody Contact contact){
        return contactService.createContact(contact);
    }
}
