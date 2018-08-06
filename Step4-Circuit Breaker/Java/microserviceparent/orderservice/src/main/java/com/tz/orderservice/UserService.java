package com.tz.orderservice;

import com.netflix.hystrix.contrib.javanica.annotation.HystrixCommand;
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

    @HystrixCommand(fallbackMethod = "getAllError")
    public List<User> getAll() {
        ParameterizedTypeReference<List<User>> responseType = new ParameterizedTypeReference<List<User>>(){};
        ResponseEntity<List<User>> resp = restTemplate.exchange(serviceUrl+"/getall",
                HttpMethod.GET, null, responseType);
        List<User> list = resp.getBody();
        return list;
    }

    @HystrixCommand(fallbackMethod = "getPortError")
    public String getPort(){
        String msg = restTemplate.getForObject(serviceUrl+"/getport", String.class);
        return msg;
    }

    public User getByName(String name){
        User user = restTemplate.getForObject(serviceUrl+"/getbyname?name="+name, User.class);
        return user;
    }

    //getAll回退方法
    public List<User> getAllError() {
        return null;
    }
    //getPort回退方法
    public String getPortError() {
        return "userservice服务断开，getPort方法调用错误!";
    }
}
