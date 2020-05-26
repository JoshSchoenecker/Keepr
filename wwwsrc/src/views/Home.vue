<template>
  <div class="home container-fluid mt-1">
    <!-- NOTE Create Keep Component -->
    <div class="row header">
      <div class="col-12">
        <h1 class="text-center mt-4">
          <CreateKeepComp class="float-left" v-if="$auth.isAuthenticated" />Keeps
          <hr class="w-50 bg-info mb-4" />
        </h1>
      </div>
    </div>
    <!-- NOTE Draws Keeps to Home view -->
    <div class="row justify-content-center">
      <KeepComp v-for="keep in keeps" :key="keep.id" :keepData="keep" />
    </div>
  </div>
</template>

<script>
import KeepComp from "../components/KeepComp.vue";
import CreateKeepComp from "../components/CreateKeepComp.vue";
export default {
  name: "home",
  mounted() {
    this.$store.dispatch("getKeeps");
  },
  computed: {
    user() {
      return this.$store.state.user;
    },

    keeps() {
      return this.$store.state.keeps;
    }
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    }
  },
  components: { KeepComp, CreateKeepComp }
};
</script>
