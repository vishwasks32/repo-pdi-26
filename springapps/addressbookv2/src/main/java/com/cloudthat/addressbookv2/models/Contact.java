package com.cloudthat.addressbookv2.models;

import jakarta.persistence.*;
import org.hibernate.annotations.CreationTimestamp;

import java.time.Instant;
import java.time.LocalDate;
import java.util.ArrayList;
import java.util.List;

@Entity(name = "Contact")
@Table(name = "AddressBook")
public class Contact {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "contactId")
    private Long id;

    @Column(name="contactName", length = 50)
    private String contactName;
    private String emailId;

    @OneToMany(mappedBy = "contact", cascade = CascadeType.ALL)
    private List<PhoneNumber> phoneNumbers = new ArrayList<PhoneNumber>();

    @Convert(converter = GenderConverter.class)
    private Gender Gender;



    @Convert(converter = org.hibernate.type.NumericBooleanConverter.class)
    private Boolean isActive = true;

    @Lob
    private byte[] profilePicture;

    private LocalDate dob;

    @CreationTimestamp
    private Instant createdAt;

    @Embedded
    private Address address;

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public String getContactName() {
        return contactName;
    }

    public void setContactName(String contactName) {
        this.contactName = contactName;
    }

    public String getEmailId() {
        return emailId;
    }

    public void setEmailId(String emailId) {
        this.emailId = emailId;
    }



    public Contact() {
    }
}
