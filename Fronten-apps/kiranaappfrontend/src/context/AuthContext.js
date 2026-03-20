"use client";
import { createContext, useContext, useEffect, useState } from 'react';
import { jwtDecode } from 'jwt-decode';


const AuthContext = createContext(null);

export const AuthProvider = ({ children }) => {
  const [user, setUser] = useState(null);

  const decodeAndSetUser = (token) => {
    try {
      const decoded = jwtDecode(token);
      
      // Note: .NET Role claim URI
      const role = decoded["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
      
      setUser({ 
        username: decoded.unique_name, 
        role 
      });
    } catch (error) {
      console.error("Invalid token:", error);
      logout();
    }
  };

  useEffect(() => {
    const token = localStorage.getItem('token');
    if (token) {
      decodeAndSetUser(token);
    }
  }, []);

  const login = (token) => {
    localStorage.setItem('token', token);
    decodeAndSetUser(token);
  };

  const logout = () => {
    localStorage.removeItem('token');
    setUser(null);
  };

  return (
    <AuthContext.Provider value={{ user, login, logout }}>
      {children}
    </AuthContext.Provider>
  );
};

export const useAuth = () => useContext(AuthContext);