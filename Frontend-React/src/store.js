import { configureStore } from '@reduxjs/toolkit'
import { setupListeners } from '@reduxjs/toolkit/query'
import { todoItemsApi } from './todoItemsApi'

export const store = configureStore({
    reducer: {
        [todoItemsApi.reducerPath]: todoItemsApi.reducer,
    
    },
    middleware: (getDefaultMiddleware) =>
        getDefaultMiddleware().concat(todoItemsApi.middleware)
})

setupListeners(store.dispatch)