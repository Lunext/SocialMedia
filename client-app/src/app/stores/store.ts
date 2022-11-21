import { createContext, useContext } from "react";
import ActivityStore from "./activityStore"

interface Store{
    activityStore:ActivityStore
}

 const store:Store={
    activityStore:new ActivityStore()
}
const StoreContext=  createContext(store);


const useStore=()=>{
    return useContext(StoreContext); 
}

export{store, StoreContext, useStore};