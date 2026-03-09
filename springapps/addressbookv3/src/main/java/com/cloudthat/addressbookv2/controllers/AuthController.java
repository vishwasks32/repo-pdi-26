package com.cloudthat.addressbookv2.controllers;

import com.cloudthat.addressbookv2.dtos.ApiResponse;
import com.cloudthat.addressbookv2.dtos.JwtRequest;
import com.cloudthat.addressbookv2.dtos.JwtResponse;
import com.cloudthat.addressbookv2.dtos.UserModel;
import com.cloudthat.addressbookv2.entities.User;
import com.cloudthat.addressbookv2.services.UserService;
import com.cloudthat.addressbookv2.utility.JWTUtility;
import jakarta.servlet.http.HttpServletRequest;
import lombok.extern.slf4j.Slf4j;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.security.authentication.AuthenticationManager;
import org.springframework.security.authentication.BadCredentialsException;
import org.springframework.security.authentication.DisabledException;
import org.springframework.security.authentication.UsernamePasswordAuthenticationToken;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RestController;

@RestController
@Slf4j
public class AuthController {

    @Autowired
    private UserService userService;

    @Autowired
    private AuthenticationManager authenticationProvider;


    @Autowired
    private JWTUtility jwtUtility;

    @PostMapping("register")
    public ResponseEntity<ApiResponse> registeruser(@RequestBody UserModel userModel, final HttpServletRequest request){
        // add check for email exists in DB
        if(userService.existsByEmail(userModel.getUsername())){
            return new ResponseEntity<ApiResponse>(new ApiResponse(false,"Email is already taken!", null, 0L), HttpStatus.BAD_REQUEST);
        }
        User registeredUser = userService.registerUser(userModel);
        return new ResponseEntity<ApiResponse>(new ApiResponse(true, "User created successfully", registeredUser, 0L), HttpStatus.CREATED);
    }

    @PostMapping("login")
    public ResponseEntity<JwtResponse> authenticate(@RequestBody JwtRequest jwtRequest) throws Exception{
        UsernamePasswordAuthenticationToken unauthenticatedToken = UsernamePasswordAuthenticationToken.unauthenticated(
                jwtRequest.getUsername(), jwtRequest.getPassword());
        try {
            authenticationProvider.authenticate(
                    unauthenticatedToken
            );
        } catch (BadCredentialsException e) {
            return new ResponseEntity<JwtResponse>(new JwtResponse(null,e.getMessage(),false,null,null),HttpStatus.UNAUTHORIZED);
        }catch(NullPointerException ex) {
            return new ResponseEntity<JwtResponse>(new JwtResponse(null,"User Name Not Found",false,null,null),HttpStatus.UNAUTHORIZED);
        }catch(DisabledException ex) {
            return new ResponseEntity<JwtResponse>(new JwtResponse(null,"User Account is disabled",false,null,null),HttpStatus.UNAUTHORIZED);
        }

        final UserDetails userDetails
                = userService.loadUserByUsername(jwtRequest.getUsername());

        final String token =
                jwtUtility.generateToken(userDetails);

        return new ResponseEntity<JwtResponse>(new JwtResponse(token,"Token generated Successfully",true, userDetails.getUsername(),userDetails.getAuthorities().iterator().next().toString()),HttpStatus.OK);
    }


}
