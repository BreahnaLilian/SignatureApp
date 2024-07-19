import React from "react";
import { useNavigate } from "react-router-dom";
import { Button } from "@mui/material";


let navigate = useNavigate();
const routeChange = () => {
    let path = `/login`;
    navigate(path);
}


const Home = () => {
    return (
        <>

            <Button
                onClick={routeChange}
            >
                Login
            </Button>

        </>
    )
}

export default Home