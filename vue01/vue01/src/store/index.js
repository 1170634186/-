import Vue from 'vue'
import Vuex from 'vuex'
import createPersistedState from "vuex-persistedstate"
Vue.use(Vuex)

export default new Vuex.Store({
  plugins: [createPersistedState({
    storage: window.sessionStorage
  })],
  state: {
    user: ""
  },
  mutations: {
    LOGIN(state, username) {
      state.user = username
    },
    QuitLogin(state) {
      state.user = ''
    }
  },
  actions: {
  },
  modules: {
  },

})

