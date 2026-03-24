package com.cloudthat.addressbookv3.dtos;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@AllArgsConstructor
@NoArgsConstructor
public class JwtResponse {

    private String jwtToken;
    private String message;
    private Boolean success;
    private String username;
    private String role;

    public JwtResponse(String jwtToken, String message, Boolean success, String username, String role) {
        this.jwtToken = jwtToken;
        this.message = message;
        this.success = success;
        this.username = username;
        this.role = role;
    }

    public String getJwtToken() {
        return jwtToken;
    }

    public void setJwtToken(String jwtToken) {
        this.jwtToken = jwtToken;
    }

    public String getMessage() {
        return message;
    }

    public void setMessage(String message) {
        this.message = message;
    }

    public Boolean getSuccess() {
        return success;
    }

    public void setSuccess(Boolean success) {
        this.success = success;
    }

    public String getEmail() {
        return username;
    }

    public void setEmail(String username) {
        this.username = username;
    }

    public String getRole() {
        return role;
    }

    public void setRole(String role) {
        this.role = role;
    }

    @Override
    public String toString() {
        return "JwtResponse{" +
                "jwtToken='" + jwtToken + '\'' +
                ", message='" + message + '\'' +
                ", success=" + success +
                ", email='" + username + '\'' +
                ", role='" + role + '\'' +
                '}';
    }
}