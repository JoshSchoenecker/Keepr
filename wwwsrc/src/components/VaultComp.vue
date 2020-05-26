<template>
  <div class="vault">
    <div class="col-3">
      <div class="card">
        <div class="card-header">
          <!-- TODO drop down elipse for DELETE & EDIT -->
        </div>
        <div class="card-title">{{vaultData.name}}</div>
        <div class="card-body">{{vaultData.description}}</div>
        <div class="card-footer">
          <!-- TODO total amount of keeps & create at date -->
        </div>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "vault",
  props:["vaultData"],
  data() {
    return {};
  },
  computed: {},
  methods: {},
  components: {}
};
</script>


<style scoped>
</style>