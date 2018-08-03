package com.tz.orderservice;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.core.ParameterizedTypeReference;
import org.springframework.http.HttpMethod;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;
import org.springframework.web.client.RestTemplate;

import java.util.ArrayList;
import java.util.List;

@Service
public class UserService {

    @Autowired
    private RestTemplate restTemplate;

    private String serviceUrl="http://userservice/user";

    public List<User> getAll() {
        ParameterizedTypeReference<List<User>> responseType = new ParameterizedTypeReference<List<User>>(){};
        ResponseEntity<List<User>> resp = restTemplate.exchange(serviceUrl+"/getall",
                HttpMethod.GET, null, responseType);
        List<User> list = resp.getBody();
        return list;
    }

    public String getPort(){
        String msg = restTemplate.getForObject(serviceUrl+"/getport", String.class);
        return msg;
    }

    public User getByName(String name){
        User user = restTemplate.getForObject(serviceUrl+"/getbyname?name="+name, User.class);
        return user;
    }
}
