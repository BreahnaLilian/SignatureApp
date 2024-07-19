import { useState } from 'react'
import { useNavigate } from "react-router-dom";
import { Routes, Route } from "react-router-dom"
import Login from './pages/Auth/Login'
import './App.css'
import { Button } from "@mui/material";

function App() {

  let navigate = useNavigate();
  const routeChange = () => {
      let path = `/login`;
      navigate(path);
  }

  return (
    <>
      <Routes>
        <Route path='/login' element={<Login />}></Route>
        <Route path='/'>Home</Route>
      </Routes>

      <Button
                onClick={routeChange}
            >
                Login
            </Button>
    </>
  )
}

export default App
