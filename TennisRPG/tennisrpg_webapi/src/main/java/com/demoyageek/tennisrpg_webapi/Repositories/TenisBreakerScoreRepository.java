package com.demoyageek.tennisrpg_webapi.Repositories;

import com.demoyageek.tennisrpg_webapi.Entities.TenisBreakerScore;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.rest.core.annotation.RepositoryRestResource;
import org.springframework.stereotype.Repository;

@Repository
@RepositoryRestResource(path = "/tbscore", collectionResourceRel = "breakerscores")
public interface TenisBreakerScoreRepository extends JpaRepository<TenisBreakerScore, Integer> {
}
